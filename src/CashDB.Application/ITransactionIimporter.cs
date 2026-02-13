using CashDB.Domain;

namespace CashDB.Application;

public interface ITransactionImporter
{
    List<Transaction> Import(string filePath);
}
