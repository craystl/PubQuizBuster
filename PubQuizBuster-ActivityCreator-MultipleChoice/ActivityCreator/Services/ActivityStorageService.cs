namespace PubQuizBuster.ActivityCreator;

public static class ActivityStorageService
{
    public static string GetOutputDirectory(string rootFilename, bool create)
    {
        var dir = Path.Combine(AppContext.BaseDirectory, "output", MakeSafeFilename(rootFilename));
        if (create) Directory.CreateDirectory(dir);
        return dir;
    }

    public static string GetDownloadsDirectory(string rootFilename, bool create)
    {
        var dir = Path.Combine(GetOutputDirectory(rootFilename, create), "downloads");
        if (create) Directory.CreateDirectory(dir);
        return dir;
    }

    public static string GetImagesDirectory(string rootFilename, bool create)
    {
        var dir = Path.Combine(GetOutputDirectory(rootFilename, create), "images");
        if (create) Directory.CreateDirectory(dir);
        return dir;
    }

    public static string MakeSafeFilename(string value)
    {
        var invalid = Path.GetInvalidFileNameChars();
        var safe = new string(value.Select(ch => invalid.Contains(ch) ? '_' : ch).ToArray());
        return safe.Replace(' ', '_');
    }
}
