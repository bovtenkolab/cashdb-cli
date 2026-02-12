namespace CashDB.Domain;

public sealed record Money
{
    public decimal Value { get; }

    public Money(decimal value)
    {
        if (value <= 0)
            throw new ArgumentOutOfRangeException(nameof(value), "Amount must be greater than zero.");

        Value = decimal.Round(value, 2, MidpointRounding.AwayFromZero);
    }
}
