using System.Runtime;
using System.Text.Json;
using CashDB.Application;
using CashDB.Domain;
using Newtonsoft.Json;

namespace CashDB.Infrastructure;

public class JsonFiles : 
    IFileSaver<Transaction>, 
    IFileReader<Transaction>
{
    private readonly JsonSerializerSettings _settings = new JsonSerializerSettings
    {
        Formatting = Formatting.Indented
    };

    public bool Save(string filePath, List<Transaction> transactions)
    {
        try
        {
            var json = JsonConvert.SerializeObject(transactions, _settings);
            File.WriteAllText(filePath, json);
        }
        catch(Exception e)
        {
            return false;
        }

        return true;
    }

    public List<Transaction> Read(string filePath)
    {
        if (!File.Exists(filePath))
            return new List<Transaction>();

        var json = File.ReadAllText(filePath);

        return JsonConvert.DeserializeObject<List<Transaction>>(json)
               ?? new List<Transaction>();
    }
}
