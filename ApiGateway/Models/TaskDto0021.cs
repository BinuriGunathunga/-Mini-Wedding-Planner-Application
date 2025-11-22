namespace ApiGateway.Models
{
    public class TaskDto0021
    {
        public int TaskId { get; set; }
        public int EventId { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Status { get; set; } = "Pending";
    }
}