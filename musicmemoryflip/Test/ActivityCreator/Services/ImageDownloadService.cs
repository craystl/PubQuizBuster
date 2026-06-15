using System.Web;

namespace PubQuizBuster.ActivityCreator;

public static class ImageDownloadService
{
    private static readonly HttpClient _redirectHttp = new HttpClient(
        new HttpClientHandler { AllowAutoRedirect = true, MaxAutomaticRedirections = 5 })
    {
        Timeout = TimeSpan.FromSeconds(20),
    };

    // Existing movies method (unchanged)
    public static async Task<string> DownloadCandidateImageAsync(
        HttpClient http,
        Candidate candidate,
        string outputDir,
        CancellationToken token)
    {
        if (string.IsNullOrWhiteSpace(candidate.ImageUrl)) return "";

        var safeName = ActivityStorageService.MakeSafeFilename($"{candidate.Name}_{candidate.WikidataId}.jpg");
        var localPath = Path.Combine(outputDir, safeName);

        if (File.Exists(localPath)) return safeName;

        var uriBuilder = new UriBuilder(candidate.ImageUrl);
        var query = HttpUtility.ParseQueryString(uriBuilder.Query);
        query["width"] = "220";
        uriBuilder.Query = query.ToString();

        var tempPath = localPath + ".download";
        try
        {
            await using (var source = await http.GetStreamAsync(uriBuilder.Uri, token))
            await using (var destination = new FileStream(tempPath, FileMode.Create, FileAccess.Write, FileShare.None))
                await source.CopyToAsync(destination, token);

            token.ThrowIfCancellationRequested();
            if (File.Exists(localPath)) File.Delete(tempPath);
            else File.Move(tempPath, localPath);
            return safeName;
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Warning: image download failed for '{candidate.Name}': {ex.Message}");
            ImageFileService.TryDeleteFile(tempPath);
            throw;
        }
    }

    // Downloads artist image from a DBpedia foaf:depiction URL.
    // DBpedia returns Wikimedia Commons Special:FilePath URLs which redirect
    // to the actual image. We force HTTPS and retry on transient failures.
    public static async Task<string> DownloadMusicArtistImageAsync(
        HttpClient _ignored,
        MusicArtistCandidate artist,
        string outputDir,
        CancellationToken token)
    {
        if (string.IsNullOrWhiteSpace(artist.ImageUrl)) return "";

        var safeName = ActivityStorageService.MakeSafeFilename($"{artist.DbpediaId}.jpg");
        var localPath = Path.Combine(outputDir, safeName);

        if (File.Exists(localPath)) return safeName;

        // Force HTTPS — Wikimedia rejects plain HTTP
        var imageUrl = artist.ImageUrl
            .Replace("http://commons.wikimedia.org", "https://commons.wikimedia.org")
            .Replace("http://upload.wikimedia.org", "https://upload.wikimedia.org");

        // Append width for FilePath URLs to get a thumbnail
        if (imageUrl.Contains("Special:FilePath") && !imageUrl.Contains("width="))
            imageUrl += "?width=220";

        var tempPath = localPath + ".download";

        // Try up to 3 times with a short delay — Wikimedia occasionally rate-limits
        for (var attempt = 1; attempt <= 3; attempt++)
        {
            try
            {
                token.ThrowIfCancellationRequested();

                using var request = new HttpRequestMessage(HttpMethod.Get, imageUrl);
                request.Headers.TryAddWithoutValidation("User-Agent",
                    "PubQuizBuster/1.0 (educational project) .NET HttpClient");
                request.Headers.TryAddWithoutValidation("Accept",
                    "image/jpeg,image/png,image/*,*/*");

                using var response = await _redirectHttp.SendAsync(
                    request, HttpCompletionOption.ResponseHeadersRead, token);

                // 429 = rate limited — wait and retry
                if ((int)response.StatusCode == 429)
                {
                    var retryAfter = response.Headers.RetryAfter?.Delta ?? TimeSpan.FromSeconds(2 * attempt);
                    await Task.Delay(retryAfter, token);
                    continue;
                }

                response.EnsureSuccessStatusCode();

                var bytes = await response.Content.ReadAsByteArrayAsync(token);
                token.ThrowIfCancellationRequested();

                // Write to temp then move — avoids partial files if cancelled
                await File.WriteAllBytesAsync(tempPath, bytes, token);
                if (File.Exists(localPath)) File.Delete(tempPath);
                else File.Move(tempPath, localPath);

                return safeName;
            }
            catch (OperationCanceledException) { throw; }
            catch when (attempt < 3)
            {
                // Brief pause before retry
                await Task.Delay(500 * attempt, token);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Warning: image download failed for '{artist.Name}': {ex.Message}");
                ImageFileService.TryDeleteFile(tempPath);
                throw;
            }
        }

        return "";
    }
}