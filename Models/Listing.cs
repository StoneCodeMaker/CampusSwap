namespace CampusSwap.Models;

public class Listing
{
    public int Id { get; set; }
    public string SellerId { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int CategoryId { get; set; }
    public ListingCondition Condition { get; set; }
    public ListingStatus Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? ClosedAt { get; set; }

    // Navigation
    public AppUser? Seller { get; set; }
    public Category? Category { get; set; }
    public ICollection<ListingImage> Images { get; set; } = new List<ListingImage>();
    public ICollection<MessageThread> Threads { get; set; } = new List<MessageThread>();
    public ICollection<Favorite> Favorites { get; set; } = new List<Favorite>();
    public ICollection<Report> Reports { get; set; } = new List<Report>();
}

