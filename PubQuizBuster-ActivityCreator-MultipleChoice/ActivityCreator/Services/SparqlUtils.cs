using System.Collections.ObjectModel;
using System.Text.Json;

namespace PubQuizBuster.ActivityCreator;

public enum LinkedDataSource
{
    Wikidata,
    Dbpedia,
}

public sealed class OscarMovieCandidateQueryOptions
{
    public string OccupationKey { get; set; } = "occupation.actor";
    public bool HasSelectedAward { get; set; } = true;
    public List<string> AwardKeys { get; set; } = new();
    public List<YearFilter> YearFilters { get; set; } = new();
    public int Limit { get; set; } = 60;
}

public static class SparqlUtils
{
    public const string WikidataSparqlEndpoint = "https://query.wikidata.org/sparql";
    public const string DbpediaSparqlEndpoint = "https://dbpedia.org/sparql";

    // Centralised lookup table for Wikidata entities and property IDs used by
    // the generated SPARQL.  The rest of the code can now refer to readable
    // keys such as "occupation.actor" or "award.oscar.bestActor" instead of
    // hard-coding values such as wd:Q33999 or wdt:P106 in the form code.
    public static readonly IReadOnlyDictionary<string, string> WikidataTerms =
        new ReadOnlyDictionary<string, string>(new Dictionary<string, string>
        {
            ["occupation.actor"] = "wd:Q33999",
            ["occupation.director"] = "wd:Q2526255",

            ["property.occupation"] = "wdt:P106",
            ["property.dateOfBirth"] = "wdt:P569",
            ["property.image"] = "wdt:P18",
            ["property.awardReceived"] = "wdt:P166",
            ["property.subclassOf"] = "wdt:P279",
            ["property.sitelinks"] = "wikibase:sitelinks",

            ["statement.awardReceived"] = "p:P166",
            ["statementValue.awardReceived"] = "ps:P166",
            ["qualifier.pointInTime"] = "pq:P585",

            ["award.oscar.bestActor"] = "wd:Q103916",
            ["award.oscar.bestActress"] = "wd:Q103618",
            ["award.oscar.bestSupportingActor"] = "wd:Q106291",
            ["award.oscar.bestSupportingActress"] = "wd:Q106301",
        });

    public static string BuildSparqlUrl(LinkedDataSource source, string sparql)
    {
        var endpoint = source switch
        {
            LinkedDataSource.Wikidata => WikidataSparqlEndpoint,
            LinkedDataSource.Dbpedia => DbpediaSparqlEndpoint,
            _ => throw new ArgumentOutOfRangeException(nameof(source), source, null),
        };

        return endpoint + "?format=json&query=" + Uri.EscapeDataString(sparql);
    }

    public static string BuildWikidataOscarMovieCandidateQuery(OscarMovieCandidateQueryOptions options)
    {
        if (options.AwardKeys.Count == 0)
            throw new ArgumentException("At least one Oscar award key is required.", nameof(options));

        var occupation = WikidataTerm(options.OccupationKey);
        var awardValues = string.Join(" ", options.AwardKeys.Select(WikidataTerm));
        var dateOfBirthFilters = new List<string>();
        var awardYearFilters = new List<string>();

        foreach (var filter in options.YearFilters)
        {
            if (filter.Field == "Date of Birth")
            {
                dateOfBirthFilters.Add($"FILTER(YEAR(?dob) {filter.Operator} {filter.Year})");
            }
            else if (filter.Field == "Year of award" && options.HasSelectedAward)
            {
                awardYearFilters.Add($"FILTER(YEAR(?awardDate) {filter.Operator} {filter.Year})");
            }
        }

        var dateOfBirthFilterBlock = JoinIndentedFilters(dateOfBirthFilters);
        var awardYearFilterBlock = JoinIndentedFilters(awardYearFilters);

        if (options.HasSelectedAward)
        {
            return $@"
SELECT DISTINCT ?person ?personLabel ?image ?dob ?award ?awardLabel ?sitelinks WHERE {{
  VALUES ?award {{ {awardValues} }}

  ?person {WikidataTerm("property.occupation")}/{WikidataTerm("property.subclassOf")}* {occupation};
          {WikidataTerm("property.dateOfBirth")} ?dob;
          {WikidataTerm("property.image")} ?image;
          {WikidataTerm("property.sitelinks")} ?sitelinks;
          {WikidataTerm("statement.awardReceived")} ?awardStatement.

  ?awardStatement {WikidataTerm("statementValue.awardReceived")} ?award.
  OPTIONAL {{ ?awardStatement {WikidataTerm("qualifier.pointInTime")} ?awardDate. }}

  {dateOfBirthFilterBlock}
  {awardYearFilterBlock}

  SERVICE wikibase:label {{ bd:serviceParam wikibase:language 'en'. }}
}}
ORDER BY DESC(?sitelinks) ?personLabel
LIMIT {options.Limit}".Trim();
        }

        return $@"
SELECT DISTINCT ?person ?personLabel ?image ?dob ?sitelinks WHERE {{
  ?person {WikidataTerm("property.occupation")}/{WikidataTerm("property.subclassOf")}* {occupation};
          {WikidataTerm("property.dateOfBirth")} ?dob;
          {WikidataTerm("property.image")} ?image;
          {WikidataTerm("property.sitelinks")} ?sitelinks.

  {dateOfBirthFilterBlock}

  FILTER NOT EXISTS {{
    VALUES ?award {{ {awardValues} }}
    ?person {WikidataTerm("property.awardReceived")} ?award.
  }}

  SERVICE wikibase:label {{ bd:serviceParam wikibase:language 'en'. }}
}}
ORDER BY DESC(?sitelinks) ?personLabel
LIMIT {options.Limit}".Trim();
    }

    public static async Task<JsonDocument> QuerySparqlJsonAsync(
        HttpClient http,
        LinkedDataSource source,
        string sparql,
        CancellationToken token)
    {
        var url = BuildSparqlUrl(source, sparql);
        using var response = await http.GetAsync(url, token);
        response.EnsureSuccessStatusCode();
        await using var stream = await response.Content.ReadAsStreamAsync(token);
        return await JsonDocument.ParseAsync(stream, cancellationToken: token);
    }

    public static async Task<List<Candidate>> QueryWikidataCandidatesAsync(
        HttpClient http,
        string sparql,
        CancellationToken token)
    {
        using var doc = await QuerySparqlJsonAsync(http, LinkedDataSource.Wikidata, sparql, token);
        var candidates = new List<Candidate>();
        var seen = new HashSet<string>();
        var bindings = doc.RootElement.GetProperty("results").GetProperty("bindings");

        foreach (var binding in bindings.EnumerateArray())
        {
            var wikidataUri = GetBinding(binding, "person");
            if (string.IsNullOrWhiteSpace(wikidataUri) || !seen.Add(wikidataUri)) continue;

            candidates.Add(new Candidate
            {
                Name = GetBinding(binding, "personLabel") ?? "Unknown",
                WikidataUrl = wikidataUri,
                WikidataId = wikidataUri.Split('/').Last(),
                ImageUrl = GetBinding(binding, "image") ?? "",
                AwardLabel = GetBinding(binding, "awardLabel"),
            });
        }

        return candidates;
    }

    public static string WikidataTerm(string key)
    {
        if (WikidataTerms.TryGetValue(key, out var value)) return value;
        throw new KeyNotFoundException($"No Wikidata term has been configured for key '{key}'.");
    }

    public static string? GetBinding(JsonElement binding, string property)
    {
        if (!binding.TryGetProperty(property, out var valueElement)) return null;
        if (!valueElement.TryGetProperty("value", out var innerValue)) return null;
        return innerValue.GetString();
    }

    private static string JoinIndentedFilters(IEnumerable<string> filters)
    {
        return string.Join("\n  ", filters);
    }
}
