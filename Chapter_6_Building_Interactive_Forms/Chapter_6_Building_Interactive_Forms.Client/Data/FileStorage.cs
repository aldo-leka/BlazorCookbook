namespace Chapter_6_Building_Interactive_Forms.Client.Data;

public sealed class FileStorage
{
    public Task UploadAsync(Stream stream, CancellationToken token = default)
    {
        Console.WriteLine("File uploaded!");
        return Task.CompletedTask;
    }
}