using CashDB.Domain;

namespace CashDB.Application;

public interface IFileSaver<T>
{
    bool Save(string filePath, List<T> items);
}
