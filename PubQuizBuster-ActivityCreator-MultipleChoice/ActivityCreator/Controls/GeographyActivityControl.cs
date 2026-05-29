using System.Diagnostics;
using System.Net.Http.Headers;
using System.Security.Policy;
using System.Text;
using System.Text.Json;
using static System.Net.WebRequestMethods;

namespace PubQuizBuster.ActivityCreator;

public sealed partial class GeographyActivityControl : UserControl
{

    private const string WikidataSparqlEndpoint = "https://query.wikidata.org/sparql";

    private static readonly Dictionary<string, string> WikidataTerms = new()
    {
        ["property.instanceOf"] = "wdt:P31",
        ["property.image"] = "wdt:P18",
        ["property.label"] = "rdfs:label",
        ["class.country"] = "wd:Q3624078",
        ["class.city"] = "wd:Q515",
        ["property.continent"] = "wdt:P30",
        ["property.country"] = "wdt:P17",
        ["property.population"] = "wdt:P1082",
        ["property.area"] = "wdt:P2046",
        ["Europe"] = "wd:Q46",
        ["Asia"] = "wd:Q48",
        ["Africa"] = "wd:Q15",
        ["North America"] = "wd:Q49",
        ["South America"] = "wd:Q18",
        ["Oceania"] = "wd:Q55643"
    };

    private readonly HttpClient _http = new();

    public GeographyActivityControl()
    {
        InitializeComponent();

        _http.DefaultRequestHeaders.UserAgent.Add(
    new ProductInfoHeaderValue("PubQuizBusterGeographySparqlQuery", "0.1"));
    }

    string? continent;
    long? minPopulation = new long?();
    long? maxPopulation = new long?();
    long? minArea = new long?();
    long? maxArea = new long?();
    string sparqlQuery;
    private void SelectionChanged(object? sender, EventArgs e)
    {
        try
        {
            continent = _continentCombo.SelectedItem.ToString();
            maxPopulation = Convert.ToInt64(_maxPopulationTextBox.Text);
            minPopulation = Convert.ToInt64(_minPopulationTextBox.Text);
            maxArea = Convert.ToInt64(_maxAreaTextBox.Text);
            minArea = Convert.ToInt64(_minAreaTextBox.Text);
            _searchButton.Enabled = true;
            sparqlQuery = buildSparqlQuery();
        }
        catch
        {
            _searchButton.Enabled = false;
        }
    }

    private string buildSparqlQuery()
    {
        var label = WikidataTerms["property.label"];
        var country = WikidataTerms["class.country"];
        var city = WikidataTerms["class.city"];

        var lines = new List<string>
        {
            "SELECT DISTINCT ?item ?itemLabel ?continent ?population ?area",
            "WHERE {",
              "?item wdt:P31 wd:Q3624078 .     # country",
              "?item wdt:P30 ?continent .      # continent",
              "?item wdt:P1082 ?population .   # population",
              "?item wdt:P2046 ?area .         # area",
              $"FILTER (?population > {minPopulation} && ?population < {maxPopulation})",
              $"FILTER (?area > {minArea} && ?area < {maxArea})",
        };
        if (continent != "any")
        {
            string continentTerm = WikidataTerms[continent];
            lines.Add($"FILTER (?continent = {continentTerm})");
        }
        lines.AddRange(new[]
        {
               "SERVICE wikibase:label { bd:serviceParam wikibase:language \"en\". }",
            "}",
            "ORDER BY ?itemLabel"
        });
        return string.Join(Environment.NewLine, lines);
    }

    private async void _searchButton_Click(object sender, EventArgs e)
    {
        buildSparqlQuery();
        _searchButton.Enabled = false;
        ClearResultsPanel();
        SetMessage("Executing SPARQL query...");

        await search();
    }

    private async Task search()
    {
        try
        {
            var queryText = sparqlQuery;
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
            _searchButton.Enabled = true;
        }
    }

    private void ClearResultsPanel()
    {
        DisposeChildControls(_resultsListBox);
    }

    private void ClearSelectedPanel()
    {
        DisposeChildControls(_selectedPanel);
    }

    private static void DisposeChildControls(Control parent)
    {
        foreach (Control child in parent.Controls.Cast<Control>().ToList())
        {
            child.Dispose();
        }
        parent.Controls.Clear();
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
            if (!binding.TryGetProperty("itemLabel", out var nameBinding)) continue;
            if (!nameBinding.TryGetProperty("value", out var value)) continue;

            _resultsListBox.Items.Add(value.GetString() ?? "(no name)");
        }
    }

    private void SetMessage(string message)
    {
        _messageTextBox.Text = message;
    }
}
