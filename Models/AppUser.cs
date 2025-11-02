using Microsoft.AspNetCore.Identity;

namespace CampusSwap.Models;

public class AppUser : IdentityUser
{
    public string Campus { get; set; } = string.Empty;
}

