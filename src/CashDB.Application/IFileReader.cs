using CashDB.Domain;

namespace CashDB.Application;

public interface IFileReader<T>
{
    List<T> Read(string filePath);
}
