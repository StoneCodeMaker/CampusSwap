namespace CampusSwap.Models;

public class ListingImage
{
    public int Id { get; set; }
    public int ListingId { get; set; }
    public string PathOrUrl { get; set; } = string.Empty;

    // Navigation
    public Listing? Listing { get; set; }
}

