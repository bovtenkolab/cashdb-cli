using CashDB.Application;

public class FileSystemInboxScanner : IInboxFileScanner
{
    public List<string> Scan(string directory, string extension)
    {
        if (!Directory.Exists(directory))
            throw new DirectoryNotFoundException();

        var searchPattern = $"*.{extension.TrimStart('.')}";
        
        return Directory.GetFiles(directory, searchPattern)
                        .Select(Path.GetFileName)
                        .ToList();
    }
}
