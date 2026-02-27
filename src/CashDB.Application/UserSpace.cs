using CashDB.Domain;
using CashDB.Infrastructure;

namespace CashDB.Application;

public class UserSpace
{
    public string InboxDirectory { get; set; }
    public string SearchExtension { get; set; }
    public List<Transaction> Transactions { get; set; }
    public string StoreFileName { get; set; }
    public string StoreFilePath { 
        get
        {
            return _storeFilePath;
        } 
    }

    private readonly string _storeFilePath;

    public UserSpace()
    {
        var mockFactory = new MockTransactionFactory();

        Transactions = mockFactory.Create();
        InboxDirectory = Directory.GetCurrentDirectory() + "/test";
        SearchExtension = "csv";
        StoreFileName = "store.json";

        _storeFilePath = InboxDirectory + "/" + StoreFileName;

        LoadTransactions();
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

    public bool LoadTransactions()
    {
        var result = new List<Transaction> ();

        var file = new JsonFiles();
        try
        {
            Transactions = file.Read(_storeFilePath);

            return true;
        }
        catch(Exception e)
        {
            return false;
        }
    }
}