namespace CampusSwap.Models;

public class MessageThread
{
    public int Id { get; set; }
    public int ListingId { get; set; }
    public string SellerId { get; set; } = string.Empty;
    public string BuyerId { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }

    // Navigation
    public Listing? Listing { get; set; }
    public AppUser? Seller { get; set; }
    public AppUser? Buyer { get; set; }
    public ICollection<Message> Messages { get; set; } = new List<Message>();
}

