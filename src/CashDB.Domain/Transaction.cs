namespace CashDB.Domain;

public sealed class Transaction
{
    public Guid Id { get; }
    public Money Amount { get; }
    public TransactionType Type { get; }
    public DateOnly Date { get; }
    public string Description { get; }

    private Transaction(
        Guid id,
        Money amount,
        TransactionType type,
        DateOnly date,
        string description)
    {
        Id = id;
        Amount = amount;
        Type = type;
        Date = date;
        Description = description;
    }

    public static Transaction Create(
        Money amount,
        TransactionType type,
        DateOnly date,
        string description)
    {
        if (string.IsNullOrWhiteSpace(description))
            throw new ArgumentException("Description is required.", nameof(description));

        if (date > DateOnly.FromDateTime(DateTime.UtcNow))
            throw new ArgumentException("Transaction date cannot be in the future.", nameof(date));

        return new Transaction(
            Guid.NewGuid(),
            amount,
            type,
            date,
            description.Trim());
    }
}
