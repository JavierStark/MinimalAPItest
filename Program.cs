using Microsoft.EntityFrameworkCore;
using MinimalAPItest;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<Database<Item>>(opt => opt.UseInMemoryDatabase("Items"));


var app = builder.Build();


app.MapGet("/", () => "This is my API!");
app.MapGet("/GetItems", async (Database<Item> db) => await db.GetAllItems());
app.MapGet("/GetItem/{name}", async (Database<Item> db, string name) => await db.GetItem(name));


app.Run();