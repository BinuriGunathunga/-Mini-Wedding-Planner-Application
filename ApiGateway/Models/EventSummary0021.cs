namespace ApiGateway.Models
{
    public class EventSummary0021
    {
        public EventDto0021? Event { get; set; }
        public List<GuestDto0021> Guests { get; set; } = new();
        public List<TaskDto0021> Tasks { get; set; } = new();
    }
}