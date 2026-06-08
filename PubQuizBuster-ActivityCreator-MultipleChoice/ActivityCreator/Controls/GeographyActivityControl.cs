using System.Collections.Specialized;
using System.ComponentModel.Design.Serialization;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Net.Quic;
using System.Security.Policy;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;
using File = System.IO.File;

namespace PubQuizBuster.ActivityCreator;

public sealed partial class GeographyActivityControl : UserControl
{

    private const string WikidataSparqlEndpoint = "https://query.wikidata.org/sparql";

    private static readonly Dictionary<string, string> WikidataTerms = new()
    {
        ["property.instanceOf"] = "wdt:P31",
        ["property.subclassOf"] = "wdt:P279",
        ["property.image"] = "wdt:P18",
        ["property.label"] = "rdfs:label",
        ["class.country"] = "wd:Q3624078",
        ["class.city"] = "wd:Q515",
        ["class.bigCity"] = "wd:Q1549591",
        ["class.territory"] = "wd:Q56061",
        ["class.subdivision"] = "wd:Q10864048",
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
            "SELECT DISTINCT ?item ?itemLabel ?population",
            "WHERE {",
            "?item " + WikidataTerms["property.population"] + " ?population.",
            "?item " + WikidataTerms["property.area"] + " ?area."
        };
        if (category == "Country")
        {
            lines.Add("?item " + WikidataTerms["property.continent"] + " ?continent.");
            lines.Add("?item " + WikidataTerms["property.instanceOf"] + " " + WikidataTerms["class.country"]);
            if (continent != "Any" && _continentCombo.SelectedItem != null)
            {
                string continentTerm = WikidataTerms[continent];
                lines.Add($"FILTER (?continent = {continentTerm})");
            }
        }
        if (category == "City")
        {
            lines.AddRange(new[]
            {
                "?item " + WikidataTerms["property.country"] + " ?country.",
                $"FILTER (?country = wd:{_countryFilterNameLabel.Tag})",
                "{",
                $"?item {WikidataTerms["property.instanceOf"]}/{WikidataTerms["property.subclassOf"]}* {WikidataTerms["class.city"]}",
                "}",
                "UNION",
                "{",
                $"?item {WikidataTerms["property.instanceOf"]}/{WikidataTerms["property.subclassOf"]}* {WikidataTerms["class.bigCity"]}",
                "}"
            });
        }
        if (category == "Subdivision")
        {
            lines.AddRange(new[]
            {
                "?item " + WikidataTerms["property.country"] + " ?country.",
                $"FILTER (?country = wd:{_countryFilterNameLabel.Tag})",
                $"?item {WikidataTerms["property.instanceOf"]}/{WikidataTerms["property.subclassOf"]}* {WikidataTerms["class.subdivision"]}",
        });
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
            "ORDER BY DESC(?population)",
            "LIMIT 50"
        });
        _filenameBox.Text = Environment.CurrentDirectory;
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

            if (!binding.TryGetProperty("item", out var itemBinding)) continue;
            if (!itemBinding.TryGetProperty("value", out var itemValue)) continue;

            string uri = itemValue.GetString() ?? "";
            string qid = uri.Split('/').Last();

            Label _returnedValueLabel = new Label();
            _returnedValueLabel.Click += _returnedValue_Click;
            _returnedValueLabel.Text = value.GetString() ?? "(no name)";
            _returnedValueLabel.Tag = qid;
            _resultsPanel.Controls.Add(_returnedValueLabel);
        }
    }

    private void SetMessage(string message)
    {
        _messageTextBox.Text = message;
    }

    public string[] currentQuestionAnswers = new string[8];
    public bool[] currentQuestionsIsCorrect = new bool[8];
    public int currentAnswerIndex = 0;

    private void _returnedValue_Click(object sender, EventArgs e)
    {
        Label clicked = sender as Label;

        string countryName = clicked.Text;
        string countryQid = clicked.Tag as string;

        Label selectedAnswer = new Label();
        selectedAnswer.Location = new Point(0, 0);
        selectedAnswer.AutoSize = true;

        if (category == "Country")
        {
            if (_countryFilterNameLabel.Text == clicked.Text)
            {
                currentAnswerIndex++;
                try
                {
                    currentQuestionAnswers[currentAnswerIndex - 1] = _countryFilterNameLabel.Text;
                    currentQuestionsIsCorrect[currentAnswerIndex - 1] = _correctAnswerCheckBox.Checked;
                }
                catch (Exception)
                {
                    currentAnswerIndex--;
                    return;
                }
                selectedAnswer.Text = _countryFilterNameLabel.Text;
                _selectedPanel.Controls.Add(selectedAnswer);
                selectedAnswer.Name = "selectedAnswer" + currentAnswerIndex.ToString();
                _countryFilterNameLabel.Text = "None";
                _countryFilterNameLabel.Tag = null;
            }
            else
            {
                _countryFilterNameLabel.Text = countryName;
                _countryFilterNameLabel.Tag = countryQid;
            }
        }
        if (category == "City" || category == "Subdivision")
        {
            currentAnswerIndex++;
            try
            {
                currentQuestionAnswers[currentAnswerIndex - 1] = _countryFilterNameLabel.Text;
                currentQuestionsIsCorrect[currentAnswerIndex - 1] = _correctAnswerCheckBox.Checked;
            }
            catch (Exception)
            {
                currentAnswerIndex--;
                return;
            }
            selectedAnswer.Text = clicked.Text;
            _selectedPanel.Controls.Add(selectedAnswer);
            selectedAnswer.Location = new Point(selectedAnswer.Location.X, selectedAnswer.Location.Y + 30);
            selectedAnswer.Name = "selectedAnswer" + currentAnswerIndex.ToString();
        }
    }

    public List<Question> questionsList = new List<Question>();
    public int numOfQuestions = 0;
    private void _completeQuestionButton_Click(object sender, EventArgs e)
    {
        Question question = new Question(_questionBox.Text, currentAnswerIndex, currentQuestionAnswers, currentQuestionsIsCorrect);
        questionsList.Add(question);
        numOfQuestions++;
        currentAnswerIndex = 0;
        Array.Clear(currentQuestionAnswers, 0, 8);
        Array.Clear(currentQuestionsIsCorrect, 0, 8);
        _selectedPanel.Controls.Clear();
        updateJsonFile(questionsList);
    }

    public Activity activity = new Activity { Questions = new List<Question>() };

    public void updateJsonFile(List<Question> questions)
    {
        activity.Type = "multiple_choice";
        activity.Title = _titleBox.Text;
        activity.NumOfQuestions = questions.Count;
        activity.Questions = questions;
    }
    private async void _saveButton_Click(object sender, EventArgs e)
    {
        await saveToFile();
    }

    private void _viewButton_Click(object sender, EventArgs e)
    {
        using var form = new Form
        {
            Text = "JSON Preview",
            Width = 760,
            Height = 620,
            StartPosition = FormStartPosition.CenterParent,
        };
        var box = new TextBox
        {
            Dock = DockStyle.Fill,
            Multiline = true,
            ScrollBars = ScrollBars.Both,
            Font = new Font("Consolas", 10),
            WordWrap = false,
        };
        form.Controls.Add(box);

        String jsonPreview = getJson();

        box.Text = jsonPreview;
        form.ShowDialog(this);
    }

    private async Task saveToFile()
    {
        string documentsPath = Path.GetDirectoryName(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));

        string filePath = Path.Combine(documentsPath, _filenameBox.Text + ".json");

        string activityJson = getJson();

        await File.WriteAllTextAsync(filePath, activityJson);
    }

    private string getJson()
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        string activityJson = JsonSerializer.Serialize(activity, options);
        return activityJson;
    }
}

public class Activity
{
    public string Type { get; set; }
    public string Title { get; set; }
    public int NumOfQuestions { get; set; }
    public List<Question> Questions { get; set; }

    public Activity()
    {
        Type = "";
        Title = "";
        NumOfQuestions = 0;
        Questions = new List<Question>();
    }
}

public class Question
{
    public string Prompt { get; set; }
    public int NumOfAnswers { get; set; }
    public List<Answer> Answers { get; set; }

    public Question(string prompt, int numOfAnswers, string[] answersText, bool[] isCorrect)
    {
        Prompt = prompt;
        NumOfAnswers = numOfAnswers;
        Answers = new List<Answer>();

        for (int i = 0; i < numOfAnswers; i++)
        {
            Answers.Add(new Answer
            {
                Text = answersText[i],
                IsCorrect = isCorrect[i]
            });
        }
    }
}

public class Answer
{
    public string Text { get; set; }
    public bool IsCorrect { get; set; }
}