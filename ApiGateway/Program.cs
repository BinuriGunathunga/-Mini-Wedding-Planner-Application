using ApiGateway.Models;
using System.Text.Json;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Register services
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

// ==================== EVENT SERVICE ROUTES ====================

// POST /gateway/events - Create event
app.MapPost("/gateway/events", async (EventDto0021 eventDto, IHttpClientFactory httpClientFactory) =>
{
    var client = httpClientFactory.CreateClient();
    var json = JsonSerializer.Serialize(eventDto);
    var content = new StringContent(json, Encoding.UTF8, "application/json");

    try
    {
        var response = await client.PostAsync("http://localhost:5001/events", content);
        var result = await response.Content.ReadAsStringAsync();

        if (response.IsSuccessStatusCode)
        {
            var createdEvent = JsonSerializer.Deserialize<EventDto0021>(result, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return Results.Ok(createdEvent);
        }
        return Results.BadRequest(result);
    }
    catch (Exception ex)
    {
        return Results.Problem($"Error: {ex.Message}");
    }
})
.WithName("GatewayCreateEvent0021")
.WithOpenApi();

// GET /gateway/events/{id} - Get event by ID
app.MapGet("/gateway/events/{id}", async (int id, IHttpClientFactory httpClientFactory) =>
{
    var client = httpClientFactory.CreateClient();

    try
    {
        var response = await client.GetAsync($"http://localhost:5001/events/{id}");
        var result = await response.Content.ReadAsStringAsync();

        if (response.IsSuccessStatusCode)
        {
            var eventDto = JsonSerializer.Deserialize<EventDto0021>(result, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return Results.Ok(eventDto);
        }
        return Results.NotFound();
    }
    catch (Exception ex)
    {
        return Results.Problem($"Error: {ex.Message}");
    }
})
.WithName("GatewayGetEvent0021")
.WithOpenApi();

// PUT /gateway/events/{id} - Update event
app.MapPut("/gateway/events/{id}", async (int id, EventDto0021 eventDto, IHttpClientFactory httpClientFactory) =>
{
    var client = httpClientFactory.CreateClient();
    var json = JsonSerializer.Serialize(eventDto);
    var content = new StringContent(json, Encoding.UTF8, "application/json");

    try
    {
        var response = await client.PutAsync($"http://localhost:5001/events/{id}", content);
        return response.IsSuccessStatusCode ? Results.Ok("Event updated") : Results.NotFound();
    }
    catch (Exception ex)
    {
        return Results.Problem($"Error: {ex.Message}");
    }
})
.WithName("GatewayUpdateEvent0021")
.WithOpenApi();

// DELETE /gateway/events/{id} - Delete event
app.MapDelete("/gateway/events/{id}", async (int id, IHttpClientFactory httpClientFactory) =>
{
    var client = httpClientFactory.CreateClient();

    try
    {
        var response = await client.DeleteAsync($"http://localhost:5001/events/{id}");
        return response.IsSuccessStatusCode ? Results.Ok("Event deleted") : Results.NotFound();
    }
    catch (Exception ex)
    {
        return Results.Problem($"Error: {ex.Message}");
    }
})
.WithName("GatewayDeleteEvent0021")
.WithOpenApi();

// ==================== GUEST SERVICE ROUTES ====================

// POST /gateway/guests - Create guest
app.MapPost("/gateway/guests", async (GuestDto0021 guestDto, IHttpClientFactory httpClientFactory) =>
{
    var client = httpClientFactory.CreateClient();
    var json = JsonSerializer.Serialize(guestDto);
    var content = new StringContent(json, Encoding.UTF8, "application/json");

    try
    {
        var response = await client.PostAsync("http://localhost:5002/guests", content);
        var result = await response.Content.ReadAsStringAsync();

        if (response.IsSuccessStatusCode)
        {
            var createdGuest = JsonSerializer.Deserialize<GuestDto0021>(result, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return Results.Ok(createdGuest);
        }
        return Results.BadRequest(result);
    }
    catch (Exception ex)
    {
        return Results.Problem($"Error: {ex.Message}");
    }
})
.WithName("GatewayCreateGuest0021")
.WithOpenApi();

// GET /gateway/guests?eventId={id} - Get guests by event
app.MapGet("/gateway/guests", async (int eventId, IHttpClientFactory httpClientFactory) =>
{
    var client = httpClientFactory.CreateClient();

    try
    {
        var response = await client.GetAsync($"http://localhost:5002/guests?eventId={eventId}");
        var result = await response.Content.ReadAsStringAsync();

        if (response.IsSuccessStatusCode)
        {
            var guests = JsonSerializer.Deserialize<List<GuestDto0021>>(result, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return Results.Ok(guests);
        }
        return Results.NotFound();
    }
    catch (Exception ex)
    {
        return Results.Problem($"Error: {ex.Message}");
    }
})
.WithName("GatewayGetGuests0021")
.WithOpenApi();

// PUT /gateway/guests/{id} - Update guest
app.MapPut("/gateway/guests/{id}", async (int id, GuestDto0021 guestDto, IHttpClientFactory httpClientFactory) =>
{
    var client = httpClientFactory.CreateClient();
    var json = JsonSerializer.Serialize(guestDto);
    var content = new StringContent(json, Encoding.UTF8, "application/json");

    try
    {
        var response = await client.PutAsync($"http://localhost:5002/guests/{id}", content);
        return response.IsSuccessStatusCode ? Results.Ok("Guest updated") : Results.NotFound();
    }
    catch (Exception ex)
    {
        return Results.Problem($"Error: {ex.Message}");
    }
})
.WithName("GatewayUpdateGuest0021")
.WithOpenApi();

// DELETE /gateway/guests/{id} - Delete guest
app.MapDelete("/gateway/guests/{id}", async (int id, IHttpClientFactory httpClientFactory) =>
{
    var client = httpClientFactory.CreateClient();

    try
    {
        var response = await client.DeleteAsync($"http://localhost:5002/guests/{id}");
        return response.IsSuccessStatusCode ? Results.Ok("Guest deleted") : Results.NotFound();
    }
    catch (Exception ex)
    {
        return Results.Problem($"Error: {ex.Message}");
    }
})
.WithName("GatewayDeleteGuest0021")
.WithOpenApi();

// ==================== TASK SERVICE ROUTES ====================

// POST /gateway/tasks - Create task
app.MapPost("/gateway/tasks", async (TaskDto0021 taskDto, IHttpClientFactory httpClientFactory) =>
{
    var client = httpClientFactory.CreateClient();
    var json = JsonSerializer.Serialize(taskDto);
    var content = new StringContent(json, Encoding.UTF8, "application/json");

    try
    {
        var response = await client.PostAsync("http://localhost:5003/tasks", content);
        var result = await response.Content.ReadAsStringAsync();

        if (response.IsSuccessStatusCode)
        {
            var createdTask = JsonSerializer.Deserialize<TaskDto0021>(result, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return Results.Ok(createdTask);
        }
        return Results.BadRequest(result);
    }
    catch (Exception ex)
    {
        return Results.Problem($"Error: {ex.Message}");
    }
})
.WithName("GatewayCreateTask0021")
.WithOpenApi();

// GET /gateway/tasks?eventId={id} - Get tasks by event
app.MapGet("/gateway/tasks", async (int eventId, IHttpClientFactory httpClientFactory) =>
{
    var client = httpClientFactory.CreateClient();

    try
    {
        var response = await client.GetAsync($"http://localhost:5003/tasks?eventId={eventId}");
        var result = await response.Content.ReadAsStringAsync();

        if (response.IsSuccessStatusCode)
        {
            var tasks = JsonSerializer.Deserialize<List<TaskDto0021>>(result, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return Results.Ok(tasks);
        }
        return Results.NotFound();
    }
    catch (Exception ex)
    {
        return Results.Problem($"Error: {ex.Message}");
    }
})
.WithName("GatewayGetTasks0021")
.WithOpenApi();

// PUT /gateway/tasks/{id} - Update task
app.MapPut("/gateway/tasks/{id}", async (int id, TaskDto0021 taskDto, IHttpClientFactory httpClientFactory) =>
{
    var client = httpClientFactory.CreateClient();
    var json = JsonSerializer.Serialize(taskDto);
    var content = new StringContent(json, Encoding.UTF8, "application/json");

    try
    {
        var response = await client.PutAsync($"http://localhost:5003/tasks/{id}", content);
        return response.IsSuccessStatusCode ? Results.Ok("Task updated") : Results.NotFound();
    }
    catch (Exception ex)
    {
        return Results.Problem($"Error: {ex.Message}");
    }
})
.WithName("GatewayUpdateTask0021")
.WithOpenApi();

// DELETE /gateway/tasks/{id} - Delete task
app.MapDelete("/gateway/tasks/{id}", async (int id, IHttpClientFactory httpClientFactory) =>
{
    var client = httpClientFactory.CreateClient();

    try
    {
        var response = await client.DeleteAsync($"http://localhost:5003/tasks/{id}");
        return response.IsSuccessStatusCode ? Results.Ok("Task deleted") : Results.NotFound();
    }
    catch (Exception ex)
    {
        return Results.Problem($"Error: {ex.Message}");
    }
})
.WithName("GatewayDeleteTask0021")
.WithOpenApi();

// ==================== SUMMARY ENDPOINT ====================

// GET /gateway/summary/{eventId} - Get complete event summary
app.MapGet("/gateway/summary/{eventId}", async (int eventId, IHttpClientFactory httpClientFactory) =>
{
    var client = httpClientFactory.CreateClient();
    var summary = new EventSummary0021();

    try
    {
        // Get event details
        var eventResponse = await client.GetAsync($"http://localhost:5001/events/{eventId}");
        if (eventResponse.IsSuccessStatusCode)
        {
            var eventJson = await eventResponse.Content.ReadAsStringAsync();
            summary.Event = JsonSerializer.Deserialize<EventDto0021>(eventJson, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        // Get guests
        var guestResponse = await client.GetAsync($"http://localhost:5002/guests?eventId={eventId}");
        if (guestResponse.IsSuccessStatusCode)
        {
            var guestJson = await guestResponse.Content.ReadAsStringAsync();
            summary.Guests = JsonSerializer.Deserialize<List<GuestDto0021>>(guestJson, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new();
        }

        // Get tasks
        var taskResponse = await client.GetAsync($"http://localhost:5003/tasks?eventId={eventId}");
        if (taskResponse.IsSuccessStatusCode)
        {
            var taskJson = await taskResponse.Content.ReadAsStringAsync();
            summary.Tasks = JsonSerializer.Deserialize<List<TaskDto0021>>(taskJson, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new();
        }

        return Results.Ok(summary);
    }
    catch (Exception ex)
    {
        return Results.Problem($"Error: {ex.Message}");
    }
})
.WithName("GatewaySummary0021")
.WithOpenApi();

app.Run();