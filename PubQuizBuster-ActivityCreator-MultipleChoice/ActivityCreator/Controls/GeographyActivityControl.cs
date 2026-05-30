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
        ["class.territoy"] = "wd:Q56061",
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
        _continentCombo.SelectedIndex = 0;
        _categoryCombo.SelectedIndex = 0;
        _http.DefaultRequestHeaders.UserAgent.Add(
        new ProductInfoHeaderValue("PubQuizBusterGeographySparqlQuery", "0.1"));
    }

    string? category;
    string? continent;
    long? minPopulation;
    long? maxPopulation;
    long? minArea;
    long? maxArea;
    bool isCorrect;
    string sparqlQuery;

    private string buildSparqlQuery()
    {
        continent = _continentCombo.SelectedItem.ToString();
        category = _categoryCombo.Text;
        isCorrect = _correctAnswerCheckBox.Checked;
        var label = WikidataTerms["property.label"];
        var country = WikidataTerms["class.country"];
        var city = WikidataTerms["class.city"];

        var lines = new List<string>
        {
            "SELECT DISTINCT ?item ?itemLabel",
            "WHERE {",
            "?item " + WikidataTerms["property.continent"] + " ?continent.",
            "?item " + WikidataTerms["property.population"] + " ?population.",
            "?item " + WikidataTerms["property.area"] + " ?area."
        };
        if (category == "Country")
        {
            lines.Add("?item " + WikidataTerms["property.instanceOf"] + " " + WikidataTerms["class.country"]);
        }
        if (category == "City")
        {
            //lines.Add("?item " + WikidataTerms["property.country"] + " ?country.");
            lines.Add("?item " + WikidataTerms["property.instanceOf"] + " " + WikidataTerms["class.city"]);
            lines.Add($"FILTER (?country = {_countryFilterNameLabel.Text}).");
        }
        if (category == "Territory")
        {
            lines.Add("?item " + WikidataTerms["property.instanceOf"] + " " + WikidataTerms["class.territory"]);
        }
        if (continent != "Any" && _continentCombo.SelectedItem != null)
        {
            string continentTerm = WikidataTerms[continent];
            lines.Add($"FILTER (?continent = {continentTerm})");
        }
        try
        {
            lines.Add($"FILTER (?population < {Convert.ToInt64(_maxPopulationTextBox.Text)})");
        }
        catch { }
        try
        {
            lines.Add($"FILTER (?population > {Convert.ToInt64(_minPopulationTextBox.Text)})");
        }
        catch { }
        try
        {
            lines.Add($"FILTER (?area < {Convert.ToInt64(_maxAreaTextBox.Text)})");
        }
        catch { }
        try
        {
            lines.Add($"FILTER (?area > {Convert.ToInt64(_minAreaTextBox.Text)})");
        }
        catch { }
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
        sparqlQuery = buildSparqlQuery();
        _searchButton.Enabled = false;
        ClearResultsPanel();
        SetMessage("Executing SPARQL query...");

        await search();
    }

    private async Task search()
    {
        try
        {
            var requestUrl = BuildRequestUrl(sparqlQuery);

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
            SetMessage($"Query complete. Returned {_resultsPanel.Controls.Count} displayed name(s).");
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
        DisposeChildControls(_resultsPanel);
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

            Label _returnedValueLabel = new Label();
            _returnedValueLabel.Click += _returnedValue_Click;
            _returnedValueLabel.Text = value.GetString() ?? "(no name)";
            _resultsPanel.Controls.Add(_returnedValueLabel);
        }
    }

    string[] currentQuestionAnswers = new string[8];
    bool[] currentQuestionsIsCorrect = new bool[8];
    int currentQuestionIndex = 0;
    private void _returnedValue_Click(object sender, EventArgs e)
    {
        currentQuestionIndex++;
        Label selectedAnswer = new Label();
        Label clicked = sender as Label;
        selectedAnswer.Location = new Point(0, 0);
        selectedAnswer.AutoSize = true;
        if (category == "Country")
        {
            if (_countryFilterNameLabel.Text == clicked.Text)
            {
                currentQuestionAnswers[currentQuestionIndex] = _countryFilterNameLabel.Text;
                selectedAnswer.Text = _countryFilterNameLabel.Text;
                _selectedPanel.Controls.Add(selectedAnswer);
                selectedAnswer.Location = new Point (selectedAnswer.Location.X,selectedAnswer.Location.Y + 30);
                _countryFilterNameLabel.Text = "None";
                selectedAnswer.Name = "selectedAnswer" + currentQuestionIndex.ToString();
            }
            else
            {
                _countryFilterNameLabel.Text = clicked.Text;
            }
        }
    }

    private void SetMessage(string message)
    {
        _messageTextBox.Text = message;
    }
}

public class Question
{
    string prompt;
    string[] answers;
    bool[] isCorrect;

    public Question(string prompt, string[] answers, bool[] isCorrect)
    {
        this.prompt = prompt;
        this.answers = answers;
        this.isCorrect = isCorrect;
    }
}