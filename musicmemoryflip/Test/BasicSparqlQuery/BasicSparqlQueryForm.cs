using System.Net.Http.Headers;
using System.Text.Json;

namespace PubQuizBuster.BasicSparqlQuery;

public partial class BasicSparqlQueryForm : Form
{
    private const string WikidataSparqlEndpoint = "https://query.wikidata.org/sparql";

    private static readonly Dictionary<string, string> WikidataTerms = new()
    {
        ["property.occupation"] = "wdt:P106",
        ["property.instanceOf"] = "wdt:P31",
        ["property.image"] = "wdt:P18",
        ["property.label"] = "rdfs:label",
        ["property.sitelinks"] = "wikibase:sitelinks",
        ["class.actor"] = "wd:Q33999",
        ["class.musician"] = "wd:Q639669",
        ["class.musicalGroup"] = "wd:Q215380"
    };

    private readonly HttpClient _http = new();

    public BasicSparqlQueryForm()
    {
        InitializeComponent();

        _http.DefaultRequestHeaders.UserAgent.Add(
            new ProductInfoHeaderValue("PubQuizBusterBasicSparqlQuery", "0.1"));

        UpdateQueryText();
        SetMessage("Ready. Edit the SPARQL if you want to experiment, then press Execute Query.");
    }

    private void SelectionChanged(object? sender, EventArgs e)
    {
        UpdateQueryText();
    }

    private void UpdateQueryText()
    {
        _queryTextBox.Text = _musiciansRadioButton.Checked
            ? BuildMusiciansBandsQuery(_withFanbaseCheckBox.Checked)
            : BuildMovieActorsQuery(_withFanbaseCheckBox.Checked);
    }

    private static string BuildMovieActorsQuery(bool withFanbase)
    {
        var occupation = WikidataTerms["property.occupation"];
        var image = WikidataTerms["property.image"];
        var label = WikidataTerms["property.label"];
        var sitelinks = WikidataTerms["property.sitelinks"];
        var actor = WikidataTerms["class.actor"];

        var lines = new List<string>
        {
            "SELECT DISTINCT",
            "    ?item",
            "    ?name",
            "    ?image"
        };

        if (withFanbase)
        {
            lines.Add("    ?sitelinks");
        }

        lines.AddRange(new[]
        {
            "WHERE",
            "{",
            "    # People whose occupation is actor.",
            $"    ?item {occupation} {actor} .",
            "",
            "    # Human-readable English name.",
            $"    ?item {label} ?name .",
            "    FILTER (LANG(?name) = \"en\")",
            "",
            "    # Image, where Wikidata has one.",
            "    OPTIONAL",
            "    {",
            $"        ?item {image} ?image .",
            "    }"
        });

        if (withFanbase)
        {
            lines.AddRange(new[]
            {
                "",
                "    # A rough 'well-known' filter: items with many Wikipedia sitelinks.",
                $"    ?item {sitelinks} ?sitelinks .",
                "    FILTER (?sitelinks >= 40)"
            });
        }

        lines.AddRange(new[]
        {
            "}",
            "LIMIT 10"
        });

        return string.Join(Environment.NewLine, lines);
    }

    private static string BuildMusiciansBandsQuery(bool withFanbase)
    {
        var occupation = WikidataTerms["property.occupation"];
        var instanceOf = WikidataTerms["property.instanceOf"];
        var image = WikidataTerms["property.image"];
        var label = WikidataTerms["property.label"];
        var sitelinks = WikidataTerms["property.sitelinks"];
        var musician = WikidataTerms["class.musician"];
        var musicalGroup = WikidataTerms["class.musicalGroup"];

        var lines = new List<string>
        {
            "SELECT DISTINCT",
            "    ?item",
            "    ?name",
            "    ?image"
        };

        if (withFanbase)
        {
            lines.Add("    ?sitelinks");
        }

        lines.AddRange(new[]
        {
            "WHERE",
            "{",
            "    # Either:",
            "    #   occupation: musician",
            "    #   instance of: musical group",
            "    VALUES (?property ?value)",
            "    {",
            $"        ({occupation} {musician})",
            $"        ({instanceOf}  {musicalGroup})",
            "    }",
            "",
            "    ?item ?property ?value .",
            "",
            "    # Human-readable English name.",
            $"    ?item {label} ?name .",
            "    FILTER (LANG(?name) = \"en\")",
            "",
            "    # Image, where Wikidata has one.",
            "    OPTIONAL",
            "    {",
            $"        ?item {image} ?image .",
            "    }"
        });

        if (withFanbase)
        {
            lines.AddRange(new[]
            {
                "",
                "    # A rough 'well-known' filter: items with many Wikipedia sitelinks.",
                $"    ?item {sitelinks} ?sitelinks .",
                "    FILTER (?sitelinks >= 40)"
            });
        }

        lines.AddRange(new[]
        {
            "}",
            "LIMIT 10"
        });

        return string.Join(Environment.NewLine, lines);
    }

    private async void ExecuteButton_Click(object? sender, EventArgs e)
    {
        _executeButton.Enabled = false;
        _resultsListBox.Items.Clear();
        _jsonTextBox.Clear();
        SetMessage("Executing SPARQL query...");

        try
        {
            var queryText = _queryTextBox.Text;
            var requestUrl = BuildRequestUrl(queryText);

            using var request = new HttpRequestMessage(HttpMethod.Get, requestUrl);
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/sparql-results+json"));
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            using var response = await _http.SendAsync(request);
            var responseText = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                _jsonTextBox.Text = responseText;
                SetMessage($"Error: HTTP {(int)response.StatusCode} {response.ReasonPhrase}");
                return;
            }

            using var jsonDocument = JsonDocument.Parse(responseText);
            _jsonTextBox.Text = JsonSerializer.Serialize(
                jsonDocument.RootElement,
                new JsonSerializerOptions { WriteIndented = true });

            DisplayReturnedNames(jsonDocument.RootElement);
            SetMessage($"Query complete. Returned {_resultsListBox.Items.Count} displayed name(s).");
        }
        catch (Exception ex)
        {
            SetMessage($"Error: {ex.Message}");
            Console.Error.WriteLine(ex);
        }
        finally
        {
            _executeButton.Enabled = true;
        }
    }

    private static string BuildRequestUrl(string queryText)
    {
        var encodedQuery = Uri.EscapeDataString(queryText);
        return $"{WikidataSparqlEndpoint}?query={encodedQuery}&format=json";
    }

    private void DisplayReturnedNames(JsonElement root)
    {
        if (!root.TryGetProperty("results", out var results)) return;
        if (!results.TryGetProperty("bindings", out var bindings)) return;

        foreach (var binding in bindings.EnumerateArray())
        {
            if (!binding.TryGetProperty("name", out var nameBinding)) continue;
            if (!nameBinding.TryGetProperty("value", out var value)) continue;

            _resultsListBox.Items.Add(value.GetString() ?? "(no name)");
        }
    }

    private void SetMessage(string message)
    {
        _messageTextBox.Text = message;
    }
}
