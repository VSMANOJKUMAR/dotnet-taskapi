using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using TaskApi;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var tasks = new List<TaskItem>();
int nextId = 1;

// GET all tasks
app.MapGet("/tasks", () => tasks);

// POST create a task
app.MapPost("/tasks", (TaskItem task) =>
{
    task.Id = nextId++;
    tasks.Add(task);
    return Results.Created($"/tasks/{task.Id}", task);
});

// PUT update a task
app.MapPut("/tasks/{id}", (int id, TaskItem updated) =>
{
    var task = tasks.FirstOrDefault(t => t.Id == id);
    if (task is null) return Results.NotFound();
    task.Title = updated.Title;
    task.IsComplete = updated.IsComplete;
    return Results.Ok(task);
});

// DELETE a task
app.MapDelete("/tasks/{id}", (int id) =>
{
    var task = tasks.FirstOrDefault(t => t.Id == id);
    if (task is null) return Results.NotFound();
    tasks.Remove(task);
    return Results.NoContent();
});

// Health check
app.MapGet("/health", () => Results.Ok("Healthy"));

await app.RunAsync();

namespace TaskApi
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public bool IsComplete { get; set; }
    }
}