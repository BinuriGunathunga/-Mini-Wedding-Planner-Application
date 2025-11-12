using GuestService.Data;
using GuestService.Models;

var builder = WebApplication.CreateBuilder(args);

// Register services
builder.Services.AddSingleton<GuestDbContext0021>();
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

// POST /guests - Add a guest (validates event exists first)
app.MapPost("/guests", async (Guest0021 newGuest, GuestDbContext0021 db, IHttpClientFactory httpClientFactory) =>
{
    // Verify event exists by calling Event Service
    var client = httpClientFactory.CreateClient();

    try
    {
        var response = await client.GetAsync($"http://localhost:5001/events/{newGuest.EventId}");

        if (!response.IsSuccessStatusCode)
        {
            return Results.BadRequest($"Event with ID {newGuest.EventId} does not exist");
        }

        var created = db.AddGuest0021(newGuest);
        return Results.Created($"/guests/{created.GuestId}", created);
    }
    catch (Exception ex)
    {
        return Results.Problem($"Error communicating with Event Service: {ex.Message}");
    }
})
.WithName("CreateGuest0021")
.WithOpenApi();

// GET /guests?eventId={id} - Get all guests for an event
app.MapGet("/guests", (int? eventId, GuestDbContext0021 db) =>
{
    if (eventId.HasValue)
    {
        var guests = db.GetGuestsByEventId0021(eventId.Value);
        return Results.Ok(guests);
    }
    return Results.Ok(db.GetAllGuests0021());
})
.WithName("GetGuests0021")
.WithOpenApi();

// GET /guests/{id} - Get guest by ID
app.MapGet("/guests/{id}", (int id, GuestDbContext0021 db) =>
{
    var guest = db.GetGuestById0021(id);
    return guest != null ? Results.Ok(guest) : Results.NotFound();
})
.WithName("GetGuestById0021")
.WithOpenApi();

// PUT /guests/{id} - Update guest
app.MapPut("/guests/{id}", (int id, Guest0021 updatedGuest, GuestDbContext0021 db) =>
{
    var success = db.UpdateGuest0021(id, updatedGuest);
    return success ? Results.Ok("Guest updated successfully") : Results.NotFound();
})
.WithName("UpdateGuest0021")
.WithOpenApi();

// DELETE /guests/{id} - Delete guest
app.MapDelete("/guests/{id}", (int id, GuestDbContext0021 db) =>
{
    var success = db.DeleteGuest0021(id);
    return success ? Results.Ok("Guest deleted successfully") : Results.NotFound();
})
.WithName("DeleteGuest0021")
.WithOpenApi();

app.Run();