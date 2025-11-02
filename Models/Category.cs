namespace CampusSwap.Models;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public ICollection<Listing> Listings { get; set; } = new List<Listing>();
}

