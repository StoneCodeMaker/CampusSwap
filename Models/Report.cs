namespace CampusSwap.Models;

public class Report
{
    public int Id { get; set; }
    public int ListingId { get; set; }
    public string ReporterId { get; set; } = string.Empty;
    public string Reason { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public ReportStatus Status { get; set; }

    // Navigation
    public Listing? Listing { get; set; }
    public AppUser? Reporter { get; set; }
}

