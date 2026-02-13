using CashDB.Domain;

namespace CashDB.Application;

public class ImportTransactionIntention
{
    private readonly ITransactionImporter _importer;

    public ImportTransactionIntention(ITransactionImporter importer)
    {
        _importer = importer;
    }

    public List<Transaction> Execute(string filePath)
    {
        return _importer.Import(filePath);
    }
}
