namespace CampusSwap.Models;

public class Message
{
    public int Id { get; set; }
    public int ThreadId { get; set; }
    public string SenderId { get; set; } = string.Empty;
    public string Body { get; set; } = string.Empty;
    public DateTime SentAt { get; set; }

    // Navigation
    public MessageThread? Thread { get; set; }
    public AppUser? Sender { get; set; }
}

