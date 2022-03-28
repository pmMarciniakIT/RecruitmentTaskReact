using Microsoft.AspNetCore.Mvc;
using RecruitmentTask.Domain.Dto;
using RecruitmentTask.Domain.Services;
using RecruitmentTask.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

// configure services
builder.Services.AddEndpointsApiExplorer();
builder.Services.ConfigureSwagger();
builder.Services.ConfigureServices();
builder.Services.ConfigureDatabase();
builder.Services.ConfigureCORS();

var app = builder.Build();

// use configuration
app.UseSwagger();
app.ConfigureSwaggerUI();
app.UseHttpsRedirection();
app.UseCors("Default");


// minimal endpoints
app.MapGet("/getAllTodos", async ([FromServices] ITodoService service)
    => await service.GetAllTodos()).WithTags("Todo Endpoints");

app.MapGet("/getExpiredTodos", async ([FromServices] ITodoService service) =>
{
    try
    {
        var response = await service.FindExpiredTodos();

        return Results.Ok(response);
    }
    catch (Exception ex)
    {
        return Results.BadRequest(ex.Message);
    }
}).WithTags("Todo Endpoints");

app.MapGet("/getTodoById", async ([FromServices] ITodoService service, Guid id) =>
{
    try
    {
        var todo = await service.GetTodoById(id);

        return Results.Ok(todo);
    }
    catch (Exception ex)
    {
        return Results.BadRequest(ex.Message);
    }
}).WithTags("Todo Endpoints");

app.MapPost("/createTodo", async ([FromServices] ITodoService service, TodoRequestDto request) =>
{
    try
    {
        var response = await service.CreateTodo(request);

        return Results.Ok(response);
    }
    catch (Exception ex)
    {
        return Results.BadRequest(ex.Message);
    }
}).WithTags("Todo Endpoints");

app.MapPut("/updateTodo", async ([FromServices] ITodoService service, TodoRequestDto request) =>
{
    try
    {
        var response = await service.UpdateTodo(request);

        return Results.Ok(response);
    }
    catch (Exception ex)
    {
        return Results.BadRequest(ex.Message);
    }
}).WithTags("Todo Endpoints");

app.MapDelete("/deleteTodo/{id}", async ([FromServices] ITodoService service, Guid id) =>
{
    try
    {
        var response = await service.DeleteTodo(id);

        return Results.Ok(response);
    }
    catch (Exception ex)
    {
        return Results.BadRequest(ex.Message);
    }
}).WithTags("Todo Endpoints");

app.Run();