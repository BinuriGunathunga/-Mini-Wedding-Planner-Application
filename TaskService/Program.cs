using TaskService.Data;
using TaskService.Models;

var builder = WebApplication.CreateBuilder(args);

// Register services
builder.Services.AddSingleton<TaskDbContext0021>();
builder.Services.AddHttpClient();

// Add Swagger services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Enable Swagger UI in development
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// POST /tasks - Add a task (validates event exists first)
app.MapPost("/tasks", async (Task0021 newTask, TaskDbContext0021 db, IHttpClientFactory httpClientFactory) =>
{
    // Verify event exists by calling Event Service
    var client = httpClientFactory.CreateClient();

    try
    {
        var response = await client.GetAsync($"http://localhost:5001/events/{newTask.EventId}");

        if (!response.IsSuccessStatusCode)
        {
            return Results.BadRequest($"Event with ID {newTask.EventId} does not exist");
        }

        var created = db.AddTask0021(newTask);
        return Results.Created($"/tasks/{created.TaskId}", created);
    }
    catch (Exception ex)
    {
        return Results.Problem($"Error communicating with Event Service: {ex.Message}");
    }
})
.WithName("CreateTask0021")
.WithOpenApi();

// GET /tasks?eventId={id} - Get all tasks for an event
app.MapGet("/tasks", (int? eventId, TaskDbContext0021 db) =>
{
    if (eventId.HasValue)
    {
        var tasks = db.GetTasksByEventId0021(eventId.Value);
        return Results.Ok(tasks);
    }
    return Results.Ok(db.GetAllTasks0021());
})
.WithName("GetTasks0021")
.WithOpenApi();

// GET /tasks/{id} - Get task by ID
app.MapGet("/tasks/{id}", (int id, TaskDbContext0021 db) =>
{
    var task = db.GetTaskById0021(id);
    return task != null ? Results.Ok(task) : Results.NotFound();
})
.WithName("GetTaskById0021")
.WithOpenApi();

// PUT /tasks/{id} - Update task
app.MapPut("/tasks/{id}", (int id, Task0021 updatedTask, TaskDbContext0021 db) =>
{
    var success = db.UpdateTask0021(id, updatedTask);
    return success ? Results.Ok("Task updated successfully") : Results.NotFound();
})
.WithName("UpdateTask0021")
.WithOpenApi();

// DELETE /tasks/{id} - Delete task
app.MapDelete("/tasks/{id}", (int id, TaskDbContext0021 db) =>
{
    var success = db.DeleteTask0021(id);
    return success ? Results.Ok("Task deleted successfully") : Results.NotFound();
})
.WithName("DeleteTask0021")
.WithOpenApi();

app.Run();