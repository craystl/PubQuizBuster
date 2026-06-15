using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace PubQuizBuster.ActivityCreator;

public sealed partial class MusicActivityControl : UserControl
{
    private readonly HttpClient _http = new HttpClient
    {
        Timeout = TimeSpan.FromSeconds(60)
    };

    private readonly MusicMemoryFlipActivity _activity = new();
    private readonly List<MusicArtistCandidate> _currentCandidates = new();
    private readonly HashSet<string> _addedArtistUris = new();
    private CancellationTokenSource? _searchCts;
    private MusicArtistCandidate? _stagedArtist;

    private static readonly (string Label, string Uri)[] GenreItems =
    {
        ("All genres",   ""),
        ("Rock",         "http://dbpedia.org/resource/Rock_music"),
        ("Pop",          "http://dbpedia.org/resource/Pop_music"),
        ("Jazz",         "http://dbpedia.org/resource/Jazz"),
        ("Hip-Hop",      "http://dbpedia.org/resource/Hip_hop_music"),
        ("Classical",    "http://dbpedia.org/resource/Classical_music"),
        ("Electronic",   "http://dbpedia.org/resource/Electronic_music"),
        ("R&B / Soul",   "http://dbpedia.org/resource/Rhythm_and_blues"),
        ("Country",      "http://dbpedia.org/resource/Country_music"),
        ("Metal",        "http://dbpedia.org/resource/Heavy_metal_music"),
        ("Reggae",       "http://dbpedia.org/resource/Reggae"),
        ("Blues",        "http://dbpedia.org/resource/Blues"),
        ("Folk",         "http://dbpedia.org/resource/Folk_music"),
        ("Punk",         "http://dbpedia.org/resource/Punk_rock"),
        ("Latin",        "http://dbpedia.org/resource/Latin_music"),
    };

    public MusicActivityControl()
    {
        InitializeComponent();
        foreach (var (label, _) in GenreItems)
            _genreCombo.Items.Add(label);
        _genreCombo.SelectedIndex = 0;
    }

    private async void _searchButton_Click(object sender, EventArgs e) => await SearchAsync();
    private void _stopButton_Click(object sender, EventArgs e) => StopSearch();
    private void _addPairButton_Click(object sender, EventArgs e) => AddSelectedPair();
    private void _viewButton_Click(object sender, EventArgs e) => ShowJsonPreview();
    private void _saveButton_Click(object sender, EventArgs e) => SaveActivity();

    private async Task SearchAsync()
    {
        _searchCts?.Cancel();
        var cts = new CancellationTokenSource();
        _searchCts = cts;
        var token = cts.Token;

        _searchButton.Enabled = false;
        _stopButton.Enabled = true;
        ClearPanel(_resultsPanel);
        _currentCandidates.Clear();
        _stagedArtist = null;
        ClearPanel(_stagingPanel);

        try
        {
            var limit = (int)_limitSpinner.Value;
            var genreIndex = _genreCombo.SelectedIndex;
            var genreUri = genreIndex >= 0 ? GenreItems[genreIndex].Uri : "";
            var downloadsDir = ActivityStorageService.GetDownloadsDirectory(GetRootFilename(), true);

            _activity.SparqlQueriesUsed.Clear();
            _statusLabel.Text = "Querying DBpedia for artists and albums ...";

            var sparql = SparqlUtils.BuildMusicCandidatesQuery(genreUri, limit);
            _activity.SparqlQueriesUsed.Add(sparql);

            var artists = await SparqlUtils.QueryAllArtistsAsync(
                _http, genreUri, limit, albumsNeeded: 2, token);

            _statusLabel.Text = $"Found {artists.Count} artists. Downloading images ...";

            var loaded = 0;
            foreach (var artist in artists)
            {
                token.ThrowIfCancellationRequested();
                _statusLabel.Text = $"Downloading image for {artist.Name} ({loaded + 1}/{artists.Count}) ...";

                try
                {
                    artist.LocalImageFile = await ImageDownloadService.DownloadMusicArtistImageAsync(
                        _http, artist, downloadsDir, token);
                }
                catch (OperationCanceledException) { throw; }
                catch { }

                _currentCandidates.Add(artist);
                AddArtistCard(artist);
                loaded++;
            }

            _statusLabel.Text = loaded == 0
                ? "No artists found. DBpedia may be unavailable or returned no results."
                : $"{loaded} artists loaded from DBpedia. Click a card to stage it, then click Add Pair.";
        }
        catch (OperationCanceledException)
        {
            _statusLabel.Text = "Search stopped.";
        }
        catch (Exception ex)
        {
            _statusLabel.Text = "Search failed: " + ex.Message;
            MessageBox.Show("Error:\n" + ex.Message, "Search failed",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            _searchButton.Enabled = true;
            _stopButton.Enabled = false;
            if (ReferenceEquals(_searchCts, cts)) { cts.Dispose(); _searchCts = null; }
        }
    }

    private void StopSearch()
    {
        _searchCts?.Cancel();
        _stopButton.Enabled = false;
        _statusLabel.Text = "Stopping ...";
    }

    private void AddArtistCard(MusicArtistCandidate artist)
    {
        var alreadyAdded = _addedArtistUris.Contains(artist.DbpediaUri);

        var card = new Panel
        {
            Width = 170,
            Height = 228,
            Margin = new Padding(8),
            BorderStyle = BorderStyle.FixedSingle,
            BackColor = alreadyAdded ? Color.LightGreen : Color.White,
            Cursor = alreadyAdded ? Cursors.Default : Cursors.Hand,
            Tag = artist.DbpediaUri,
        };

        var pic = new PictureBox
        {
            Width = 154,
            Height = 140,
            Left = 7,
            Top = 7,
            SizeMode = PictureBoxSizeMode.Zoom,
            BackColor = Color.Gainsboro,
        };

        if (!string.IsNullOrWhiteSpace(artist.LocalImageFile))
        {
            var path = Path.Combine(
                ActivityStorageService.GetDownloadsDirectory(GetRootFilename(), false),
                artist.LocalImageFile);
            if (File.Exists(path))
                pic.Image = ImageFileService.LoadImageWithoutLockingFile(path);
        }

        var lbl = new Label
        {
            Text = artist.Name + "\n\u2022 " + artist.AlbumNames[0] + "\n\u2022 " + artist.AlbumNames[1],
            Left = 7,
            Top = 152,
            Width = 154,
            Height = 70,
            Font = new Font("Segoe UI", 8f),
            TextAlign = ContentAlignment.TopLeft,
        };

        card.Controls.Add(pic);
        card.Controls.Add(lbl);

        void OnClick(object? s, EventArgs ev)
        {
            if (!_addedArtistUris.Contains(artist.DbpediaUri))
                StageArtist(artist);
        }
        card.Click += OnClick;
        pic.Click += OnClick;
        lbl.Click += OnClick;

        _resultsPanel.Controls.Add(card);
    }

    // Clicking a card just sets the staged artist and updates the status bar.
    // Nothing is shown in the staging panel yet — that only happens on Add Pair.
    private void StageArtist(MusicArtistCandidate artist)
    {
        _stagedArtist = artist;
        _statusLabel.Text = "Staged: " + artist.Name + ". Click Add Pair to add to activity.";
    }

    private void MarkCardAdded(string dbpediaUri)
    {
        foreach (Control ctrl in _resultsPanel.Controls)
        {
            if (ctrl is Panel card && card.Tag is string tag && tag == dbpediaUri)
            {
                card.BackColor = Color.LightGreen;
                card.Cursor = Cursors.Default;
            }
        }
    }

    private void AddSelectedPair()
    {
        if (_stagedArtist == null)
        {
            MessageBox.Show("Click an artist card first.", "Nothing staged",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var artist = _stagedArtist;

        var safeName = artist.Name.ToLower()
            .Replace(" ", "")
            .Replace("(", "").Replace(")", "")
            .Replace(".", "").Replace("'", "")
            .Replace("/", "").Replace("&", "");

        var artistImageFile = "";
        if (!string.IsNullOrWhiteSpace(artist.LocalImageFile))
        {
            var src = Path.Combine(ActivityStorageService.GetDownloadsDirectory(GetRootFilename(), false), artist.LocalImageFile);
            var imagesDir = ActivityStorageService.GetImagesDirectory(GetRootFilename(), true);
            var dest = Path.Combine(imagesDir, artist.LocalImageFile);
            if (File.Exists(src) && !File.Exists(dest)) File.Copy(src, dest);
            artistImageFile = "images/" + artist.LocalImageFile;
        }

        // 2 album cards
        for (int i = 0; i < artist.AlbumNames.Count; i++)
        {
            _activity.Cards.Add(new MemoryFlipCard
            {
                Id = safeName + "-album-0" + (i + 1),
                Img = "",
                CardType = "album-cover",
                Label = artist.AlbumNames[i],
                MatchingName = artist.Name,
                ArtistName = artist.Name,
                AlbumTitle = artist.AlbumNames[i],
            });
        }

        // 1 artist card
        _activity.Cards.Add(new MemoryFlipCard
        {
            Id = safeName + "-artist-01",
            Img = artistImageFile,
            CardType = "artist-photo",
            Label = artist.Name,
            MatchingName = artist.Name,
            ArtistName = artist.Name,
        });

        _addedArtistUris.Add(artist.DbpediaUri);
        MarkCardAdded(artist.DbpediaUri);
        _stagedArtist = null;

        // Add a permanent entry to the staging panel — stays visible
        // so the user can see everything they've added so far
        var entry = new Label
        {
            Text = "\u2705 " + artist.Name + "\n    \u2022 " + artist.AlbumNames[0] + "\n    \u2022 " + artist.AlbumNames[1],
            Width = 300,
            Height = 80,
            Font = new Font("Segoe UI", 8.5f),
            TextAlign = ContentAlignment.TopLeft,
            Padding = new Padding(4, 4, 0, 0),
            BorderStyle = BorderStyle.FixedSingle,
            Margin = new Padding(0, 0, 0, 4),
        };
        _stagingPanel.Controls.Add(entry);

        var groupCount = _activity.Cards.Count / 3;
        _statusLabel.Text = "Added " + artist.Name + ". Activity now has " + groupCount + " artist group(s).";
    }

    private string BuildJson()
    {
        _activity.Title = string.IsNullOrWhiteSpace(_titleBox.Text)
            ? "Music Memory Flip" : _titleBox.Text.Trim();
        _activity.ActivityId = GetRootFilename();
        return JsonSerializer.Serialize(_activity, new JsonSerializerOptions { WriteIndented = true });
    }

    private void ShowJsonPreview()
    {
        using var dlg = new Form { Text = "JSON Preview", Width = 800, Height = 600, StartPosition = FormStartPosition.CenterParent };
        dlg.Controls.Add(new TextBox { Dock = DockStyle.Fill, Multiline = true, ScrollBars = ScrollBars.Both, Font = new Font("Consolas", 9), Text = BuildJson(), WordWrap = false });
        dlg.ShowDialog(this);
    }

    private void SaveActivity()
    {
        try
        {
            var outputDir = ActivityStorageService.GetOutputDirectory(GetRootFilename(), true);
            var path = Path.Combine(outputDir, GetRootFilename() + ".json");
            File.WriteAllText(path, BuildJson(), Encoding.UTF8);
            _statusLabel.Text = "Saved to " + path;
            MessageBox.Show("Saved:\n" + path, "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Save failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private string GetRootFilename()
    {
        var t = _filenameBox.Text.Trim();
        return string.IsNullOrWhiteSpace(t) ? "music_memory_flip" : t;
    }

    private static void ClearPanel(Control panel)
    {
        foreach (Control c in panel.Controls.Cast<Control>().ToList()) c.Dispose();
        panel.Controls.Clear();
    }
}