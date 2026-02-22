using System.Runtime;
using CashDB.Application;
using CashDB.Domain;

namespace CashDB.Infrastructure;

public class JsonFileSaver : IFileSaver<Transaction>
{
    public bool Save(string path, List<Transaction> items)
    {
        return false;        
    }
}
