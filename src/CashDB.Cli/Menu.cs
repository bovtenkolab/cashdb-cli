using System.Runtime.CompilerServices;
using CashDB.Domain;
using CashDB.Application;
using CashDB.Infrastructure;

namespace CashDB.Cli;

internal static class Menu
{
    public static void ShowMenu(UserSpace space)
    {
        while (true)
        {
            PrintHeader(space.InboxDirectory);

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
                    var import = new ImportTransactionIntention(importer);

                    Console.Clear();                    
                    import.HandleImport(space);
                    Pause();
                    break;

                case "3":
                    Console.Clear();
                    Console.WriteLine("Type absolute directory of inbox and press enter...");
                    Console.WriteLine();                    

                    input = Console.ReadLine();
                    var result = space.SetInbox(input);
                    
                    if (result)
                    {
                        Console.Clear();
                        PrintInbox(space.InboxDirectory);
                    }
                    else
                    {
                        Console.WriteLine("Something went wrong.");
                    }

                    Pause();
                    
                    break;

                case "4":
                    var saver = new JsonFileSaver();
                    var save = new SaveFileIntention<Transaction>(saver);

                    Console.Clear();  

                    try
                    {
                        save.Records = space.Transactions;
                        save.TargetPath = Directory.GetCurrentDirectory() + "/test/store.json";

                        if (!save.Save())
                            throw new Exception();
                    }      
                    catch (Exception e)
                    {
                        Console.WriteLine("Something went wrong.");
                    }

                    Pause();
                    break;

                case "0":
                    return;

                default:                    

                    Pause();
                    break;
            }
        }
    }

    private static void PrintHeader(string directory = "")
    {
        Console.Clear();
        Console.WriteLine("==== Main Menu ====");
        Console.WriteLine("1. View All Transactions");
        Console.WriteLine("2. Import Transactions (CSV)");
        Console.WriteLine("3. Set Inbox Directory");
        Console.WriteLine("4. Save Transactions");
        Console.WriteLine("0. Exit");
        Console.WriteLine();

        PrintInbox(directory);
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

    private static void PrintInbox(string directory)
    {        
        Console.WriteLine($"Inbox: {directory}");        
    }
}
