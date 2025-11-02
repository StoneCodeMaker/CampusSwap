namespace CampusSwap.Models;

public class Favorite
{
    public string UserId { get; set; } = string.Empty;
    public int ListingId { get; set; }

    // Navigation
    public AppUser? User { get; set; }
    public Listing? Listing { get; set; }
}

