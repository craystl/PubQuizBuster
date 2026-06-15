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

    // ── Movies query (unchanged) ──────────────────────────────────────────────

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
                dateOfBirthFilters.Add($"FILTER(YEAR(?dob) {filter.Operator} {filter.Year})");
            else if (filter.Field == "Year of award" && options.HasSelectedAward)
                awardYearFilters.Add($"FILTER(YEAR(?awardDate) {filter.Operator} {filter.Year})");
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

    // ── DBpedia music ─────────────────────────────────────────────────────────

    /// <summary>
    /// Builds a single DBpedia SPARQL query that returns musical artists and
    /// two of their albums in one request — matching the pattern used by the
    /// Movies tab which does one Wikidata query for all candidates at once.
    ///
    /// The query works by:
    ///   1. Finding resources typed as dbo:MusicalArtist that have a depiction
    ///      (so we get an image) and an English label.
    ///   2. Finding albums linked to those artists via any of the three
    ///      predicates DBpedia uses: dbo:artist, dbo:musicalArtist, dbp:artist.
    ///   3. Excluding singles and songs via FILTER NOT EXISTS.
    ///   4. Using a sub-select to pick the first two albums per artist so we
    ///      don't get hundreds of rows for one artist.
    /// </summary>
    public static string BuildMusicCandidatesQuery(string genreUri, int limit)
    {
        var genreFilter = string.IsNullOrWhiteSpace(genreUri)
            ? ""
            : $"  ?artist dbo:genre <{genreUri}> .\n";

        // Simple flat query — no subqueries, no ranking properties.
        // This is the version confirmed to work against DBpedia.
        // We request limit*10 rows so the grouping step has enough
        // rows to fill `limit` artists with 2 albums each.
        return $@"PREFIX dbo:  <http://dbpedia.org/ontology/>
PREFIX dbp:  <http://dbpedia.org/property/>
PREFIX rdfs: <http://www.w3.org/2000/01/rdf-schema#>
PREFIX foaf: <http://xmlns.com/foaf/0.1/>

SELECT DISTINCT ?artist ?artistName ?artistImage ?album ?albumName WHERE {{

  ?artist a dbo:MusicalArtist ;
          rdfs:label ?artistName ;
          foaf:depiction ?artistImage .
{genreFilter}
  FILTER(LANG(?artistName) = 'en')

  {{
    ?album dbo:artist ?artist ;
           rdfs:label ?albumName .
  }} UNION {{
    ?album dbo:musicalArtist ?artist ;
           rdfs:label ?albumName .
  }} UNION {{
    ?album dbp:artist ?artist ;
           rdfs:label ?albumName .
  }}

  FILTER(LANG(?albumName) = 'en')
  FILTER NOT EXISTS {{ ?album a dbo:Single }}
  FILTER NOT EXISTS {{ ?album a dbo:Song   }}

}}
ORDER BY ?artist ?albumName
LIMIT {limit * 10}".Trim();
    }

    // Kept so the SPARQL log in the saved JSON still shows the query used
    public static string BuildArtistQuery(string artistDbpediaId)
        => BuildMusicCandidatesQuery("", 500);

    // Kept for JSON provenance
    public static string BuildDbpediaMusicArtistAlbumQuery(MusicArtistAlbumQueryOptions options)
        => BuildMusicCandidatesQuery(options.GenreUri, options.Limit);

    /// <summary>
    /// Runs the single bulk DBpedia query and groups results into one
    /// MusicArtistCandidate per artist, each with exactly albumsNeeded albums.
    /// Artists with fewer than albumsNeeded albums in DBpedia are skipped.
    /// </summary>
    public static async Task<List<MusicArtistCandidate>> QueryAllArtistsAsync(
        HttpClient http,
        string genreUri,
        int limit,
        int albumsNeeded,
        CancellationToken token)
    {
        // We request more rows than we need because the LIMIT applies to rows,
        // not to artists — each artist+album pair is one row.
        var rowLimit = limit * 20;
        var sparql = BuildMusicCandidatesQuery(genreUri, rowLimit);

        using var doc = await QuerySparqlJsonAsync(http, LinkedDataSource.Dbpedia, sparql, token);
        var bindings = doc.RootElement.GetProperty("results").GetProperty("bindings");

        // Group rows by artist URI
        var artistMap = new Dictionary<string, MusicArtistCandidate>();
        var artistOrder = new List<string>(); // preserve ORDER BY from SPARQL

        foreach (var binding in bindings.EnumerateArray())
        {
            var artistUri = GetBinding(binding, "artist") ?? "";
            var artistName = GetBinding(binding, "artistName") ?? "";
            var artistImage = GetBinding(binding, "artistImage") ?? "";
            var albumUri = GetBinding(binding, "album") ?? "";
            var albumName = GetBinding(binding, "albumName") ?? "";

            if (string.IsNullOrWhiteSpace(artistUri) || string.IsNullOrWhiteSpace(albumName))
                continue;

            if (!artistMap.TryGetValue(artistUri, out var candidate))
            {
                candidate = new MusicArtistCandidate
                {
                    Name = artistName,
                    DbpediaUri = artistUri,
                    DbpediaId = artistUri.Split('/').Last(),
                    ImageUrl = artistImage,
                    AlbumNames = new List<string>(),
                    AlbumUris = new List<string>(),
                };
                artistMap[artistUri] = candidate;
                artistOrder.Add(artistUri);
            }

            // Keep updating ImageUrl in case the first row had no image binding
            if (string.IsNullOrWhiteSpace(candidate.ImageUrl) && !string.IsNullOrWhiteSpace(artistImage))
                candidate.ImageUrl = artistImage;

            // Only keep up to albumsNeeded albums per artist
            if (candidate.AlbumNames.Count < albumsNeeded &&
                !candidate.AlbumNames.Contains(albumName, StringComparer.OrdinalIgnoreCase))
            {
                candidate.AlbumNames.Add(albumName);
                candidate.AlbumUris.Add(albumUri);
            }
        }

        // Only return artists that have enough albums, up to the requested limit
        return artistOrder
            .Select(uri => artistMap[uri])
            .Where(c => c.AlbumNames.Count >= albumsNeeded)
            .Take(limit)
            .ToList();
    }

    // ── Shared HTTP helpers ───────────────────────────────────────────────────

    public static async Task<JsonDocument> QuerySparqlJsonAsync(
        HttpClient http,
        LinkedDataSource source,
        string sparql,
        CancellationToken token)
    {
        var url = BuildSparqlUrl(source, sparql);
        var request = new HttpRequestMessage(HttpMethod.Get, url);
        request.Headers.TryAddWithoutValidation(
            "User-Agent",
            "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/120.0.0.0 Safari/537.36");
        request.Headers.TryAddWithoutValidation(
            "Accept",
            "application/sparql-results+json, application/json");

        using var response = await http.SendAsync(request, token);
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

    public static string? GetBinding(JsonElement binding, string property, bool dummy)
        => GetBinding(binding, property);

    private static string JoinIndentedFilters(IEnumerable<string> filters)
        => string.Join("\n  ", filters);
}