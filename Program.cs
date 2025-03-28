using Cdv;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<PeopleDatabase>(options =>
{
    var connection = builder.Configuration.GetConnectionString("DatabaseConnectionString");
    options.UseSqlServer(connection);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

// var summaries = new[]
// {
//     "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
// };

app.MapGet("/people", (PeopleDatabase Database) =>
{
    return Database.People.ToList();
})
.WithName("GetPeople");

app.MapPost("/people", (PeopleDatabase Database, PersonClass PersonToAdd) =>
{
    Database.People.Add(PersonToAdd);
    Database.SaveChanges();
})
.WithName("AddPerson");


app.Run();

// record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
// {
//     public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
// }
