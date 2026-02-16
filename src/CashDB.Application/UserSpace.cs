using CashDB.Domain;
using CashDB.Infrastructure;

namespace CashDB.Application;

public class UserSpace
{
    public string InboxDirectory { get; set; }
    public string SearchExtension { get; set; }

    public List<Transaction> Transactions { get; set; }

    public UserSpace()
    {
        var mockFactory = new MockTransactionFactory();

        Transactions = mockFactory.Create();
        InboxDirectory = Directory.GetCurrentDirectory();
        SearchExtension = "csv";
    }

    public bool SetInbox(string directory)
    {
        try 
        {
            if (Directory.Exists(directory))
            {
                InboxDirectory = directory;    
                return true;                           
            }

            throw new Exception();
        }
        catch(Exception e)
        {
            return false;
        }
    }
}