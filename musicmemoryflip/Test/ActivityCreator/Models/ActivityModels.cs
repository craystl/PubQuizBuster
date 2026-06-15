using System.Text.Json.Serialization;

namespace PubQuizBuster.ActivityCreator;

public sealed record YearFilter(string Field, string Operator, int Year);

public sealed class Candidate
{
    public string Name { get; set; } = "";
    public string WikidataId { get; set; } = "";
    public string WikidataUrl { get; set; } = "";
    public string ImageUrl { get; set; } = "";
    public string? LocalImageFile { get; set; }
    public string? AwardLabel { get; set; }
    public bool IsOddOneOut { get; set; }
}

public sealed class QuizActivity
{
    [JsonPropertyName("type")]
    public string Type { get; set; } = "odd-one-out";

    [JsonPropertyName("title")]
    public string Title { get; set; } = "Untitled Movies Activity";

    [JsonPropertyName("questions")]
    public List<OddOneOutQuestion> Questions { get; set; } = new();
}

public sealed class OddOneOutQuestion
{
    [JsonPropertyName("prompt")]
    public string Prompt { get; set; } = "";

    [JsonPropertyName("answers")]
    public List<SelectedAnswer> Answers { get; set; } = new();
}

public sealed class SelectedAnswer
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = "";

    [JsonPropertyName("wikidataId")]
    public string WikidataId { get; set; } = "";

    [JsonPropertyName("wikidataUrl")]
    public string WikidataUrl { get; set; } = "";

    [JsonPropertyName("imageFile")]
    public string LocalImageFile { get; set; } = "";

    [JsonPropertyName("isCorrectOddOneOut")]
    public bool IsCorrectOddOneOut { get; set; }

    [JsonPropertyName("explanation")]
    public string Explanation { get; set; } = "";

    public SelectedAnswer Clone() => new()
    {
        Name = Name,
        WikidataId = WikidataId,
        WikidataUrl = WikidataUrl,
        LocalImageFile = LocalImageFile,
        IsCorrectOddOneOut = IsCorrectOddOneOut,
        Explanation = Explanation,
    };
}

// ── Music Memory Flip models ──────────────────────────────────────────────────

public sealed class MusicArtistAlbumQueryOptions
{
    public string ArtistDbpediaId { get; set; } = "";
    public int AlbumsPerArtist { get; set; } = 2;
    public int MinAlbums { get; set; } = 2;
    public string GenreUri { get; set; } = "";
    public int Limit { get; set; } = 30;
}

public sealed class MusicArtistCandidate
{
    public string Name { get; set; } = "";
    public string DbpediaUri { get; set; } = "";
    public string DbpediaId { get; set; } = "";
    public string ImageUrl { get; set; } = "";
    public string? LocalImageFile { get; set; }
    public List<string> AlbumNames { get; set; } = new();
    public List<string> AlbumUris { get; set; } = new();
}

// ── Output format — matches the frontend test JSON exactly ────────────────────

public sealed class MusicMemoryFlipActivity
{
    [JsonPropertyName("activityType")]
    public string ActivityType { get; set; } = "matching-cards";

    [JsonPropertyName("activityId")]
    public string ActivityId { get; set; } = "music-memory-flip";

    [JsonPropertyName("title")]
    public string Title { get; set; } = "Music Memory Flip";

    [JsonPropertyName("description")]
    public string Description { get; set; } = "Match the artist with their albums";

    [JsonPropertyName("matchSize")]
    public int MatchSize { get; set; } = 3;

    [JsonPropertyName("cards")]
    public List<MemoryFlipCard> Cards { get; set; } = new();

    // Kept for provenance — not read by the frontend
    [JsonPropertyName("sparqlQueriesUsed")]
    public List<string> SparqlQueriesUsed { get; set; } = new();
}

public sealed class MemoryFlipCard
{
    [JsonPropertyName("id")]
    public string Id { get; set; } = "";

    [JsonPropertyName("img")]
    public string Img { get; set; } = "";

    [JsonPropertyName("cardType")]
    public string CardType { get; set; } = "";

    [JsonPropertyName("label")]
    public string Label { get; set; } = "";

    [JsonPropertyName("matchingName")]
    public string MatchingName { get; set; } = "";

    [JsonPropertyName("artistName")]
    public string ArtistName { get; set; } = "";

    [JsonPropertyName("albumTitle")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? AlbumTitle { get; set; }
}