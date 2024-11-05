using ListaAPI.Data;
using ListaAPI.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseSqlite(builder.Configuration.GetConnectionString("SqliteConnection")));

var app = builder.Build();



//app.UseHttpsRedirection();

app.MapGet("api/todo", async (AppDbContext context) =>
{
    var items = await context.zakupyToDos.ToListAsync();

    return Results.Ok(items);
});

app.MapPost("api/todo", async (AppDbContext context, ZakupyToDo zakupyToDo) =>
{
    await context.zakupyToDos.AddAsync(zakupyToDo);

    await context.SaveChangesAsync();

    return Results.Created($"api/todo/{zakupyToDo.Id}", zakupyToDo);
});

app.MapPut("api/todo/{id}", async (AppDbContext context, int id, ZakupyToDo zakupyToDo) =>
{
    var ZakupyToDoModel = await context.zakupyToDos.FirstOrDefaultAsync(t => t.Id == id);

    if (ZakupyToDoModel == null)
    {
        return Results.NotFound();
    }
    ZakupyToDoModel.ZakupyToDoName = zakupyToDo.ZakupyToDoName;

    await context.SaveChangesAsync();

    return Results.NoContent();
});

app.MapDelete("api/todo/{id}", async (AppDbContext context, int id) =>
{
    var ZakupyToDoModel = await context.zakupyToDos.FirstOrDefaultAsync(t => t.Id == id);

    if (ZakupyToDoModel == null)
    {
        return Results.NotFound();
    }
    context.zakupyToDos.Remove(ZakupyToDoModel);

    await context.SaveChangesAsync();

    return Results.NoContent() ;
});

app.Run();

