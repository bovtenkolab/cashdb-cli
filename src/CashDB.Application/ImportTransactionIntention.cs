using CashDB.Domain;

namespace CashDB.Application;

public class ImportTransactionIntention
{
    private readonly ITransactionImporter _importer;
    private List<string> CandidateFiles {get; set;}


    public ImportTransactionIntention(ITransactionImporter importer)
    {
        _importer = importer;
        CandidateFiles = new List<string>();
    }

    public List<Transaction> Execute(string filePath)
    {
        return _importer.Import(filePath);
    }

    public void SetCandidateFiles(string inbox)
    {
        CandidateFiles = Directory.GetFiles(inbox, "*.csv").ToList();
    }
    
    public void HandleImport(string inbox = "")
    {       
        Console.Clear();
        Console.WriteLine("Select CSV file to import:");
        Console.WriteLine();

        SetCandidateFiles(inbox);

        if (CandidateFiles.Count == 0)
        {
            Console.WriteLine("No files found.");
            return;
        }

        for (int i = 0; i < CandidateFiles.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {Path.GetFileName(CandidateFiles[i])}");
        }

        Console.WriteLine();
        Console.Write("Enter file number: ");

        if (!int.TryParse(Console.ReadLine(), out int selection) ||
            selection < 1 || selection > CandidateFiles.Count)
        {
            Console.WriteLine("Invalid selection.");
            return;
        }

        var selectedFile = CandidateFiles[selection - 1];

        var imported = Execute(selectedFile);

        var transactions = new List<Transaction>();
        transactions.AddRange(imported);

        Console.WriteLine();
        Console.WriteLine($"Imported {imported.Count} transactions.");
    }
}
