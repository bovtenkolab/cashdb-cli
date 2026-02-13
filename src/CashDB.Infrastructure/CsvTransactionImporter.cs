using System.Runtime;
using CashDB.Application;
using CashDB.Domain;

namespace CashDB.Infrastructure;

public class CsvTransactionImporter : ITransactionImporter
{
    public List<Transaction> Import(string filePath)
    {
        var lines = File.ReadAllLines(filePath);
        var transactions = new List<Transaction>();

        foreach (var line in lines.Skip(1)) // skip header
        {
            decimal credit, debit;
            DateOnly date;

            var columns = line.Split(',');

            DateOnly.TryParse(columns[0], out date);
            
            var description = columns[1];
            
            decimal.TryParse(columns[2], out debit);
            decimal.TryParse(columns[3], out credit);

            if (debit == 0 && credit == 0)
            {}

            if (debit > 0 && credit > 0)
            {}

            TransactionType type;
            decimal amount;
            
            if (credit != 0)
            {
                type = Enum.Parse<TransactionType>("Credit", true);
                amount = credit;
            }
            else
            {
                type = Enum.Parse<TransactionType>("Debit", true);
                amount = debit;
            }

            var transaction = Transaction.Create(
                new Money(amount),
                type,
                date,
                description);

            transactions.Add(transaction);
        }

        return transactions;
    }
}
