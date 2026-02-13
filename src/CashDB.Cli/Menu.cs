using System.Runtime.CompilerServices;
using CashDB.Domain;
using CashDB.Application;
using CashDB.Infrastructure;

namespace CashDB.Cli;

internal static class Menu
{
    public static void ShowMenu(List<Transaction> transactions)
    {
        while (true)
        {
            PrintHeader();

            var input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    Console.Clear();
                    TransactionPrinter.Print(transactions);
                    Pause();
                    break;

                case "2":
                    var importer = new CsvTransactionImporter();
                    var importAction = new ImportTransactionIntention(importer);

                    Console.Clear();
                    HandleImport(importAction);
                    Pause();
                    break;

                case "0":
                    return;

                default:
                    Console.Clear();
                    Console.WriteLine("Invalid selection.");
                    Pause();
                    break;
            }
        }
    }

    private static void PrintHeader()
    {
        Console.Clear();
        Console.WriteLine("==== Main Menu ====");
        Console.WriteLine("1. View All Transactions");
        Console.WriteLine("2. Import Transactions (CSV)");
        Console.WriteLine("0. Exit");
        Console.WriteLine();
        Console.Write("Select option: ");
        Console.WriteLine();
    }

    private static void Pause()
    {
        Console.WriteLine();
        Console.WriteLine("Press any key to return to menu...");
        Console.ReadKey(true);
    }

        private static void HandleImport(ImportTransactionIntention useCase)
    {
        Console.Clear();
        Console.WriteLine("Select CSV file to import:");
        Console.WriteLine();

        var files = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.csv");

        if (files.Length == 0)
        {
            Console.WriteLine("No CSV files found.");
            return;
        }

        for (int i = 0; i < files.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {Path.GetFileName(files[i])}");
        }

        Console.WriteLine();
        Console.Write("Enter file number: ");

        if (!int.TryParse(Console.ReadLine(), out int selection) ||
            selection < 1 || selection > files.Length)
        {
            Console.WriteLine("Invalid selection.");
            return;
        }

        var selectedFile = files[selection - 1];

        var imported = useCase.Execute(selectedFile);

        var transactions = new List<Transaction>();
        transactions.AddRange(imported);

        Console.WriteLine();
        Console.WriteLine($"Imported {imported.Count} transactions.");
    }
}
