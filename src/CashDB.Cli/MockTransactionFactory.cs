using CashDB.Domain;

namespace CashDB.Cli;

internal static class MockTransactionFactory
{
    public static List<Transaction> Create()
    {
        var rawData = new List<string[]>
        {
            new[] { "2026-02-01", "Credit", "1200.00", "Salary" },
            new[] { "2026-02-03", "Debit",  "85.40",   "Groceries" },
            new[] { "2026-02-05", "Debit",  "60.00",   "Internet Bill" },
            new[] { "2026-02-07", "X", "0",  "Freelance Work" }
        };

        var transactions = new List<Transaction>();

        foreach (var row in rawData)
        {
            try {
                var date = DateOnly.Parse(row[0]);

                var type = Enum.Parse<TransactionType>(
                    row[1],
                    ignoreCase: true);

                var amountValue = decimal.Parse(row[2]);
                var money = new Money(amountValue);

                var description = row[3];

                var transaction = Transaction.Create(
                    money,
                    type,
                    date,
                    description);

                transactions.Add(transaction);
            }
            catch (Exception e)
            {
                
            }
        }

        return transactions;
    }
}
