using CashDB.Domain;

namespace CashDB.Cli;

internal static class Menu
{
    public static void ShowMenu(List<Transaction> transactions)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("==== Main Menu ====");
            Console.WriteLine("1. View All Transactions");
            Console.WriteLine("0. Exit");
            Console.WriteLine();
            Console.Write("Select option: ");

            var input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    TransactionPrinter.Print(transactions);
                    Pause();
                    break;

                case "0":
                    return;

                default:
                    Console.WriteLine("Invalid selection.");
                    Pause();
                    break;
            }
        }
    }

    private static void Pause()
    {
        Console.WriteLine();
        Console.WriteLine("Press any key to return to menu...");
        Console.ReadKey(true);
    }
}
