using System.Runtime.CompilerServices;
using CashDB.Domain;
using CashDB.Application;
using CashDB.Infrastructure;

namespace CashDB.Cli;

internal static class Menu
{
    public static void ShowMenu()
    {
        while (true)
        {
            var space = new UserSpace();

            PrintHeader();

            var input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    Console.Clear();
                    TransactionPrinter.Print(space.Transactions);
                    Pause();
                    break;

                case "2":
                    var importer = new CsvTransactionImporter();
                    var intent = new ImportTransactionIntention(importer);

                    Console.Clear();
                    intent.HandleImport();
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
}
