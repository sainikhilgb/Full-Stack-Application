using api;
using efscaffold.Entities;
using Infrastructure.Postgres.Scaffolding;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var appOptions = builder.Services.AddAppOptions(builder.Configuration);

builder.Services.AddDbContext<MyDbContext>(conf => conf.UseNpgsql(appOptions.DbConnectionString));

builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options =>
{
    options.SerializerOptions.TypeInfoResolver = new System.Text.Json.Serialization.Metadata.DefaultJsonTypeInfoResolver();
});
var app = builder.Build();

app.MapGet("/", ([FromServices] MyDbContext dbContext) =>
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
