using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Linq;

namespace MinimalAPItest;

public sealed class Database<T> : DbContext where T : class, new()
{
    public Database(DbContextOptions<Database<T>> options) : base(options)
    {
        using StreamReader reader = new("./initialItems.json");
        var json = reader.ReadToEnd();

        
        var items = JsonConvert.DeserializeObject<List<T>>(json);

        foreach (var item in items)
        {
            Console.Out.WriteLine(JsonConvert.SerializeObject(item));
            var model = (IModel)item;
            model.Id = Guid.NewGuid().ToString("N");
        }
        Table.AddRange(items);
        SaveChanges();
    }

    private DbSet<T> Table => Set<T>();
    
    public async Task<List<T>> GetAllItems() => await Table.ToListAsync();
    
    public async Task<T> GetItem(string name)
    {
        var list = await Table.ToListAsync();
        
        return list.FirstOrDefault(item => ((IModel)item).Name == name, new T());
    }
}
