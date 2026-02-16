public class ListInboxFilesIntention
{
    private readonly IInboxFileScanner _scanner;

    public ListInboxFilesIntention(IInboxFileScanner scanner)
    {
        _scanner = scanner;
    }

    public List<string> Execute(string directory, string extension)
    {
        var files = _scanner.Scan(directory, extension);
        
        return files;
    }
}
