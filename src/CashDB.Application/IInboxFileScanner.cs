public interface IInboxFileScanner
{
    List<string> Scan(string directory, string extension);
}
