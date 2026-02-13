using CashDB.Domain;

namespace CashDB.Cli;

internal static class TransactionPrinter
{
    public static void Print(IEnumerable<Transaction> transactions)
    {
        Console.Clear();
        Console.WriteLine("==== Transactions ====");
        Console.WriteLine();
        Console.WriteLine(
            $"{ "Date",-12} | { "Type",-6} | { "Amount",10} | Description");
        Console.WriteLine(new string('-', 60));

        foreach (var t in transactions)
        {
            var sign = t.Type == TransactionType.Debit ? "-" : "+";
            var amount = $"{sign}{t.Amount.Value:0.00}";

            Console.WriteLine(
                $"{t.Date,-12:yyyy-MM-dd} | {t.Type,-6} | {amount,10} | {t.Description}");
        }

        Console.WriteLine();
    }
}
