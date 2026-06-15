namespace PubQuizBuster.ActivityCreator;

public static class ImageFileService
{
    public static Image LoadImageWithoutLockingFile(string path)
    {
        using var source = Image.FromFile(path);
        return new Bitmap(source);
    }

    public static void TryDeleteFile(string path)
    {
        try
        {
            if (!string.IsNullOrWhiteSpace(path) && File.Exists(path))
                File.Delete(path);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Warning: failed to delete file '{path}': {ex.Message}");
        }
    }
}
