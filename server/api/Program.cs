using efscaffold.Entities;
using Infrastructure.Postgres.Scaffolding;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MyDbContext>(conf=>conf.UseNpgsql(
    builder.Configuration.GetSection("AppOptions:DbConnectionString").Value
    ));
var app = builder.Build();

app.MapGet("/", ([FromServices]MyDbContext dbContext) =>
{
    var todoObject = new Todo()
    {
        Id = Guid.NewGuid().ToString(),
        Title = "New Todo",
        Description = "Test Todo",
        Priority = 1,
        Isdone = false
    };
    dbContext.Add(todoObject);
    dbContext.SaveChanges();
    var Todo = dbContext.Todos.ToList();
    return Results.Ok(Todo);
});

app.Run();
