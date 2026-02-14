using CashDB.Domain;
using CashDB.Infrastructure;

namespace CashDB.Application;

public class UserSpace
{
    public List<Transaction> Transactions { get; set; }

    public UserSpace()
    {
        var mockFactory = new MockTransactionFactory();

        Transactions = mockFactory.Create();
    }
}