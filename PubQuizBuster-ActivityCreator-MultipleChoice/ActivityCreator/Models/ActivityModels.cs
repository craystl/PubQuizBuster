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
