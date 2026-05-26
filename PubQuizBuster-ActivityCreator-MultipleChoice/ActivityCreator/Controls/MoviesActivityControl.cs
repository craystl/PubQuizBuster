using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace PubQuizBuster.ActivityCreator;

public sealed partial class MoviesActivityControl : UserControl
{
    private readonly QuizActivity _activity = new();
    private readonly List<SelectedAnswer> _currentQuestionAnswers = new();
    private readonly List<Candidate> _currentCandidates = new();
    private readonly HttpClient _http = new();
    private CancellationTokenSource? _searchCancellation;

    public MoviesActivityControl()
    {
        InitializeComponent();

        _http.DefaultRequestHeaders.UserAgent.Add(
            new ProductInfoHeaderValue("PubQuizBusterActivityCreatorDemo", "0.1"));

        UpdateActivityFromHeader();
    }

    private void TitleBox_TextChanged(object? sender, EventArgs e) => UpdateActivityFromHeader();

    private void LoadButton_Click(object? sender, EventArgs e)
    {
        MessageBox.Show("To be implemented ...", "Load", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void ViewButton_Click(object? sender, EventArgs e) => ShowJsonPreview();

    private void SaveButton_Click(object? sender, EventArgs e) => SaveActivity();

    private async void SearchButton_Click(object? sender, EventArgs e) => await SearchAsync();

    private void StopButton_Click(object? sender, EventArgs e) => StopSearch();

    private void CompleteQuestionButton_Click(object? sender, EventArgs e) => CompleteQuestion();

    private async Task SearchAsync()
    {
        _searchCancellation?.Cancel();
        var cts = new CancellationTokenSource();
        _searchCancellation = cts;
        var token = cts.Token;

        try
        {
            _searchButton.Enabled = false;
            _stopButton.Enabled = true;

            // A fresh search should replace the displayed search results, but keep
            // the downloaded image files on disk so they can be reused later.
            ClearResultsPanel();
            _currentCandidates.Clear();
            _statusLabel.Text = "Building SPARQL query ...";

            var query = BuildSparqlQuery();
            token.ThrowIfCancellationRequested();
            _statusLabel.Text = "Querying Wikidata ...";

            var candidates = await QueryWikidataAsync(query, token);
            _statusLabel.Text = $"Found {candidates.Count} candidates. Downloading thumbnail images ...";

            var downloadsDir = GetDownloadsDirectory(create: true);
            foreach (var candidate in candidates)
            {
                token.ThrowIfCancellationRequested();
                candidate.LocalImageFile = await ImageDownloadService.DownloadCandidateImageAsync(_http, candidate, downloadsDir, token);
                token.ThrowIfCancellationRequested();
                _currentCandidates.Add(candidate);
                AddCandidateCard(candidate);
            }

            _statusLabel.Text = $"Displayed {_currentCandidates.Count} candidates. Click images to add them to the current question.";
        }
        catch (OperationCanceledException)
        {
            _statusLabel.Text = "Search stopped. Any partly downloaded image has been removed.";
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Search failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            _statusLabel.Text = "Search failed.";
        }
        finally
        {
            _searchButton.Enabled = true;
            _stopButton.Enabled = false;

            if (ReferenceEquals(_searchCancellation, cts))
            {
                cts.Dispose();
                _searchCancellation = null;
            }
        }
    }

    private void StopSearch()
    {
        _statusLabel.Text = "Stopping search ...";
        _stopButton.Enabled = false;
        _searchCancellation?.Cancel();
    }

    private string BuildSparqlQuery()
    {
        var awardKeys = GetSelectedOscarAwardKeys();
        if (awardKeys.Count == 0)
            throw new InvalidOperationException("Select at least one Oscar award category.");

        var options = new OscarMovieCandidateQueryOptions
        {
            OccupationKey = _occupationCombo.SelectedItem?.ToString() == "Director"
                ? "occupation.director"
                : "occupation.actor",
            HasSelectedAward = _hasCombo.SelectedItem?.ToString() == "has",
            AwardKeys = awardKeys,
            YearFilters = new[]
            {
                GetYearFilter(_yearFilter1FieldCombo, _yearFilter1OperatorCombo, _yearFilter1YearBox),
                GetYearFilter(_yearFilter2FieldCombo, _yearFilter2OperatorCombo, _yearFilter2YearBox)
            }
                .Where(filter => filter is not null)
                .Cast<YearFilter>()
                .ToList(),
        };

        return SparqlUtils.BuildWikidataOscarMovieCandidateQuery(options);
    }

    private List<string> GetSelectedOscarAwardKeys()
    {
        var awards = new List<string>();
        if (_bestActorCheck.Checked) awards.Add("award.oscar.bestActor");
        if (_bestActressCheck.Checked) awards.Add("award.oscar.bestActress");
        if (_bestSupportingActorCheck.Checked) awards.Add("award.oscar.bestSupportingActor");
        if (_bestSupportingActressCheck.Checked) awards.Add("award.oscar.bestSupportingActress");
        return awards;
    }

    private static YearFilter? GetYearFilter(ComboBox fieldCombo, ComboBox operatorCombo, TextBox yearBox)
    {
        var field = fieldCombo.SelectedItem?.ToString();
        if (field is null || field == "Ignore") return null;
        if (!int.TryParse(yearBox.Text.Trim(), out var year)) return null;
        return new YearFilter(field, operatorCombo.SelectedItem?.ToString() ?? ">", year);
    }


    private async Task<List<Candidate>> QueryWikidataAsync(string sparql, CancellationToken token)
    {
        var candidates = await SparqlUtils.QueryWikidataCandidatesAsync(_http, sparql, token);

        foreach (var candidate in candidates)
        {
            candidate.IsOddOneOut = _hasCombo.SelectedItem?.ToString() == "has not";
        }

        return candidates;
    }

    private void AddCandidateCard(Candidate candidate)
    {
        var card = new Panel
        {
            Width = 170,
            Height = 228,
            Margin = new Padding(8),
            BorderStyle = BorderStyle.FixedSingle,
            BackColor = Color.White,
            Cursor = Cursors.Hand,
        };

        var picture = new PictureBox
        {
            Width = 154,
            Height = 160,
            Left = 7,
            Top = 7,
            SizeMode = PictureBoxSizeMode.Zoom,
            BackColor = Color.Gainsboro,
        };
        var imagePath = Path.Combine(GetDownloadsDirectory(create: false), candidate.LocalImageFile ?? "");
        if (File.Exists(imagePath))
        {
            picture.Image = ImageFileService.LoadImageWithoutLockingFile(imagePath);
        }

        var label = new Label
        {
            Text = candidate.Name,
            Width = 154,
            Height = 46,
            Left = 7,
            Top = 172,
            TextAlign = ContentAlignment.TopCenter,
        };

        card.Controls.Add(picture);
        card.Controls.Add(label);
        card.Click += (_, _) => SelectCandidate(candidate);
        picture.Click += (_, _) => SelectCandidate(candidate);
        label.Click += (_, _) => SelectCandidate(candidate);

        _resultsPanel.Controls.Add(card);
    }

    private void SelectCandidate(Candidate candidate)
    {
        if (_currentQuestionAnswers.Any(a => a.WikidataId == candidate.WikidataId))
        {
            _statusLabel.Text = $"{candidate.Name} is already selected for this question.";
            return;
        }

        if (_currentQuestionAnswers.Count >= 4)
        {
            _statusLabel.Text = "This question already has four selected answers.";
            return;
        }

        var selectedImageFile = CopyCandidateImageToQuestionImages(candidate);

        var selected = new SelectedAnswer
        {
            Name = candidate.Name,
            WikidataId = candidate.WikidataId,
            WikidataUrl = candidate.WikidataUrl,
            LocalImageFile = selectedImageFile,
            IsCorrectOddOneOut = candidate.IsOddOneOut,
            Explanation = candidate.IsOddOneOut
                ? "No selected acting Oscar category is recorded for this person in Wikidata."
                : "A selected acting Oscar category is recorded for this person in Wikidata.",
        };

        _currentQuestionAnswers.Add(selected);
        AddSelectedCard(selected);
        _statusLabel.Text = $"Added {selected.Name}. Current question has {_currentQuestionAnswers.Count}/4 answers.";
    }

    private string CopyCandidateImageToQuestionImages(Candidate candidate)
    {
        if (string.IsNullOrWhiteSpace(candidate.LocalImageFile)) return "";

        var sourcePath = Path.Combine(GetDownloadsDirectory(create: false), candidate.LocalImageFile);
        if (!File.Exists(sourcePath)) return "";

        var imagesDir = GetImagesDirectory(create: true);
        var safeFilename = ActivityStorageService.MakeSafeFilename(Path.GetFileName(candidate.LocalImageFile));
        var destinationPath = Path.Combine(imagesDir, safeFilename);

        // Keep one canonical copy of each selected image in the images folder.
        // If the image has already been copied for a previous question, reuse it.
        if (!File.Exists(destinationPath))
        {
            File.Copy(sourcePath, destinationPath);
        }

        return Path.Combine("images", safeFilename).Replace('\\', '/');
    }

    private void AddSelectedCard(SelectedAnswer answer)
    {
        var card = new Panel
        {
            Width = 285,
            Height = 102,
            Margin = new Padding(4),
            BorderStyle = BorderStyle.FixedSingle,
            BackColor = answer.IsCorrectOddOneOut ? Color.MistyRose : Color.White,
        };

        var picture = new PictureBox
        {
            Width = 74,
            Height = 86,
            Left = 6,
            Top = 6,
            SizeMode = PictureBoxSizeMode.Zoom,
            BackColor = Color.Gainsboro,
        };
        var imagePath = Path.Combine(GetOutputDirectory(create: false), answer.LocalImageFile);
        if (File.Exists(imagePath))
        {
            picture.Image = ImageFileService.LoadImageWithoutLockingFile(imagePath);
        }

        var label = new Label
        {
            Text = answer.IsCorrectOddOneOut ? $"{answer.Name}\nODD ONE OUT" : answer.Name,
            Left = 86,
            Top = 8,
            Width = 190,
            Height = 70,
            TextAlign = ContentAlignment.MiddleLeft,
        };

        card.Controls.Add(picture);
        card.Controls.Add(label);
        _selectedPanel.Controls.Add(card);
    }

    private void CompleteQuestion()
    {
        if (_currentQuestionAnswers.Count != 4)
        {
            MessageBox.Show("Select exactly four images before completing the question.", "Incomplete question", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (_currentQuestionAnswers.Count(a => a.IsCorrectOddOneOut) != 1)
        {
            MessageBox.Show("Exactly one selected answer should be the odd one out. Try selecting three from a 'has' search and one from a 'has not' search.", "Check selected answers", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        UpdateActivityFromHeader();
        _activity.Questions.Add(new OddOneOutQuestion
        {
            Prompt = _questionBox.Text.Trim(),
            Answers = _currentQuestionAnswers.Select(a => a.Clone()).ToList(),
        });

        _currentQuestionAnswers.Clear();
        _currentCandidates.Clear();
        ClearResultsPanel();
        ClearSelectedPanel();
        _statusLabel.Text = $"Completed question. Activity now contains {_activity.Questions.Count} question(s).";
    }

    private void ClearResultsPanel()
    {
        DisposeChildControls(_resultsPanel);
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

    private void UpdateActivityFromHeader()
    {
        _activity.Type = "odd-one-out";
        _activity.Title = string.IsNullOrWhiteSpace(_titleBox?.Text) ? "Untitled Movies Activity" : _titleBox.Text.Trim();
    }

    private string GetJsonText()
    {
        UpdateActivityFromHeader();
        var options = new JsonSerializerOptions { WriteIndented = true };
        return JsonSerializer.Serialize(_activity, options);
    }

    private void ShowJsonPreview()
    {
        using var form = new Form
        {
            Text = "Current JSON Preview",
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
            Text = GetJsonText(),
            WordWrap = false,
        };
        form.Controls.Add(box);
        form.ShowDialog(this);
    }

    private void SaveActivity()
    {
        try
        {
            var outputDir = GetOutputDirectory(create: true);
            var root = ActivityStorageService.MakeSafeFilename(GetRootFilename());
            var path = Path.Combine(outputDir, root + ".json");
            File.WriteAllText(path, GetJsonText(), Encoding.UTF8);
            _statusLabel.Text = $"Saved {path}";
            MessageBox.Show($"Saved JSON to:\n{path}\n\nDownloaded search-result images are cached in:\n{GetDownloadsDirectory(create: true)}\n\nSelected question images are stored in:\n{GetImagesDirectory(create: true)}", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Save failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private string GetOutputDirectory(bool create) =>
        ActivityStorageService.GetOutputDirectory(GetRootFilename(), create);

    private string GetDownloadsDirectory(bool create) =>
        ActivityStorageService.GetDownloadsDirectory(GetRootFilename(), create);

    private string GetImagesDirectory(bool create) =>
        ActivityStorageService.GetImagesDirectory(GetRootFilename(), create);

    private string GetRootFilename()
    {
        var root = _filenameBox?.Text?.Trim();
        return string.IsNullOrWhiteSpace(root) ? "movie_odd_one_out" : root;
    }
}

