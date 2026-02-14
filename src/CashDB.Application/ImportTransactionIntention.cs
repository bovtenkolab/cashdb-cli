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

    private void SetCandidateFiles()
    {
        var path = Directory.GetCurrentDirectory() + "/test";
        candidateFiles = Directory.GetFiles(path, "*.csv").ToList();
    }

    // public static void HandleImport(ImportTransactionIntention useCase)
    // {       

    //     Console.WriteLine();
    //     Console.Write("Enter file number: ");

    //     if (!int.TryParse(Console.ReadLine(), out int selection) ||
    //         selection < 1 || selection > files.Length)
    //     {
    //         Console.WriteLine("Invalid selection.");
    //         return;
    //     }

    //     var selectedFile = files[selection - 1];

    //     var imported = useCase.Execute(selectedFile);

    //     var transactions = new List<Transaction>();
    //     transactions.AddRange(imported);

    //     Console.WriteLine();
    //     Console.WriteLine($"Imported {imported.Count} transactions.");
    // }
}
