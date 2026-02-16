using CashDB.Domain;

namespace CashDB.Application;

public class ImportTransactionIntention
{
    private readonly ITransactionImporter _importer;
    private List<string> candidateFiles;


    public ImportTransactionIntention(ITransactionImporter importer)
    {
        _importer = importer;
        candidateFiles = new List<string>();
    }

    public List<Transaction> Execute(string filePath)
    {
        return _importer.Import(filePath);
    }

    public void SetCandidateFiles()
    {
        var path = Directory.GetCurrentDirectory() + "/test";
        candidateFiles = Directory.GetFiles(path, "*.csv").ToList();
    }
    
    public void HandleImport()
    {       
        Console.Clear();
        Console.WriteLine("Select CSV file to import:");
        Console.WriteLine();

        SetCandidateFiles();

        if (candidateFiles.Count == 0)
        {
            Console.WriteLine("No files found.");
            return;
        }

        for (int i = 0; i < candidateFiles.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {Path.GetFileName(candidateFiles[i])}");
        }

        Console.WriteLine();
        Console.Write("Enter file number: ");

        if (!int.TryParse(Console.ReadLine(), out int selection) ||
            selection < 1 || selection > candidateFiles.Count)
        {
            Console.WriteLine("Invalid selection.");
            return;
        }

        var selectedFile = candidateFiles[selection - 1];

        var imported = Execute(selectedFile);

        var transactions = new List<Transaction>();
        transactions.AddRange(imported);

        Console.WriteLine();
        Console.WriteLine($"Imported {imported.Count} transactions.");
    }
}
