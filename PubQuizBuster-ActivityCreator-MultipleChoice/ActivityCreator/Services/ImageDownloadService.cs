using System.Web;

namespace PubQuizBuster.ActivityCreator;

public static class ImageDownloadService
{
    public static async Task<string> DownloadCandidateImageAsync(
        HttpClient http,
        Candidate candidate,
        string outputDir,
        CancellationToken token)
    {
        if (string.IsNullOrWhiteSpace(candidate.ImageUrl)) return "";

        var safeName = ActivityStorageService.MakeSafeFilename($"{candidate.Name}_{candidate.WikidataId}.jpg");
        var localPath = Path.Combine(outputDir, safeName);

        // Reuse images that have already been downloaded in a previous search.
        if (File.Exists(localPath)) return safeName;

        // width=220 gives a thumbnail suitable for a desktop authoring UI.
        var uriBuilder = new UriBuilder(candidate.ImageUrl);
        var query = HttpUtility.ParseQueryString(uriBuilder.Query);
        query["width"] = "220";
        uriBuilder.Query = query.ToString();

        var tempPath = localPath + ".download";
        try
        {
            await using (var source = await http.GetStreamAsync(uriBuilder.Uri, token))
            await using (var destination = new FileStream(tempPath, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                await source.CopyToAsync(destination, token);
            }

            token.ThrowIfCancellationRequested();

            if (File.Exists(localPath))
                File.Delete(tempPath);
            else
                File.Move(tempPath, localPath);

            return safeName;
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Warning: image download failed for '{candidate.Name}' from '{candidate.ImageUrl}': {ex.Message}");
            ImageFileService.TryDeleteFile(tempPath);
            throw;
        }
    }
}
