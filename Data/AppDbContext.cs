using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CampusSwap.Models;

namespace CampusSwap.Data;

public class AppDbContext : IdentityDbContext<AppUser>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Listing> Listings { get; set; }
    public DbSet<ListingImage> ListingImages { get; set; }
    public DbSet<MessageThread> MessageThreads { get; set; }
    public DbSet<Message> Messages { get; set; }
    public DbSet<Favorite> Favorites { get; set; }
    public DbSet<Report> Reports { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Composite key for Favorite
        builder.Entity<Favorite>()
            .HasKey(f => new { f.UserId, f.ListingId });

        builder.Entity<Favorite>()
            .HasOne(f => f.User)
            .WithMany()
            .HasForeignKey(f => f.UserId);

        builder.Entity<Favorite>()
            .HasOne(f => f.Listing)
            .WithMany(l => l.Favorites)
            .HasForeignKey(f => f.ListingId);

        // MessageThread relationships
        builder.Entity<MessageThread>()
            .HasOne(t => t.Seller)
            .WithMany()
            .HasForeignKey(t => t.SellerId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<MessageThread>()
            .HasOne(t => t.Buyer)
            .WithMany()
            .HasForeignKey(t => t.BuyerId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<MessageThread>()
            .HasOne(t => t.Listing)
            .WithMany(l => l.Threads)
            .HasForeignKey(t => t.ListingId);

        // Message relationships
        builder.Entity<Message>()
            .HasOne(m => m.Thread)
            .WithMany(t => t.Messages)
            .HasForeignKey(m => m.ThreadId);

        builder.Entity<Message>()
            .HasOne(m => m.Sender)
            .WithMany()
            .HasForeignKey(m => m.SenderId)
            .OnDelete(DeleteBehavior.Restrict);

        // Listing relationships
        builder.Entity<Listing>()
            .HasOne(l => l.Seller)
            .WithMany()
            .HasForeignKey(l => l.SellerId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Listing>()
            .HasOne(l => l.Category)
            .WithMany(c => c.Listings)
            .HasForeignKey(l => l.CategoryId);

        builder.Entity<ListingImage>()
            .HasOne(i => i.Listing)
            .WithMany(l => l.Images)
            .HasForeignKey(i => i.ListingId)
            .OnDelete(DeleteBehavior.Cascade);

        // Report relationships
        builder.Entity<Report>()
            .HasOne(r => r.Listing)
            .WithMany(l => l.Reports)
            .HasForeignKey(r => r.ListingId);

        builder.Entity<Report>()
            .HasOne(r => r.Reporter)
            .WithMany()
            .HasForeignKey(r => r.ReporterId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

