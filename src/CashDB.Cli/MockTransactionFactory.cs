using ExpenseTracker.Domain;

namespace ExpenseTracker.Cli;

internal static class MockTransactionFactory
{
    public static List<Transaction> Create()
    {
        return new List<Transaction>
        {
            Transaction.Create(
                new Money(1200m),
                TransactionType.Credit,
                new DateOnly(2026, 2, 1),
                "Salary"),

            Transaction.Create(
                new Money(85.40m),
                TransactionType.Debit,
                new DateOnly(2026, 2, 3),
                "Groceries"),

            Transaction.Create(
                new Money(60m),
                TransactionType.Debit,
                new DateOnly(2026, 2, 5),
                "Internet Bill"),

            Transaction.Create(
                new Money(200m),
                TransactionType.Credit,
                new DateOnly(2026, 2, 7),
                "Freelance Work")
        };
    }
}
