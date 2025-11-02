using CampusSwap.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;

namespace CampusSwap.Data;

public static class SeedData
{
    public static void Initialize(AppDbContext context, IServiceProvider serviceProvider)
    {
        var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
        var logger = loggerFactory?.CreateLogger("SeedData");
        
        try
        {
            logger?.LogInformation("Starting database seeding");
            
            if (context.Categories.Any())
            {
                logger?.LogInformation("Database already seeded, skipping");
                return;
            }

            logger?.LogInformation("Seeding categories");
            // Add categories
            var categories = new[]
        {
            new Category { Name = "Books" },
            new Category { Name = "Tech" },
            new Category { Name = "Furniture" },
            new Category { Name = "Clothing" },
            new Category { Name = "Tickets" },
            new Category { Name = "Misc" }
        };

            try
            {
                context.Categories.AddRange(categories);
                context.SaveChanges();
                logger?.LogInformation("Successfully added {Count} categories", categories.Length);
            }
            catch (Exception ex)
            {
                logger?.LogError(ex, "Error seeding categories");
                throw;
            }

            // Create test user if not exists
            try
            {
                logger?.LogInformation("Checking for test user");
                var userManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();
                
                if (!context.Users.Any(u => u.Email == "student@liberty.edu"))
                {
                    logger?.LogInformation("Creating test user");
                    var testUser = new AppUser
                    {
                        UserName = "student@liberty.edu",
                        Email = "student@liberty.edu",
                        EmailConfirmed = true,
                        Campus = "Liberty University"
                    };
                    var result = userManager.CreateAsync(testUser, "Test123!").Result;
                    
                    if (result.Succeeded)
                    {
                        logger?.LogInformation("Test user created successfully");
                    }
                    else
                    {
                        logger?.LogWarning("Failed to create test user: {Errors}", 
                            string.Join(", ", result.Errors.Select(e => e.Description)));
                    }
                }
                else
                {
                    logger?.LogInformation("Test user already exists");
                }
            }
            catch (Exception ex)
            {
                logger?.LogError(ex, "Error creating test user");
            }
        
            try
            {
                context.SaveChanges();
                logger?.LogInformation("Context saved after user creation");
            }
            catch (Exception ex)
            {
                logger?.LogError(ex, "Error saving context after user creation");
            }

            var user = context.Users.FirstOrDefault(u => u.Email == "student@liberty.edu");
            if (user == null)
            {
                logger?.LogWarning("Test user not found, skipping listing creation");
                return;
            }
            
            logger?.LogInformation("Found test user with ID: {UserId}", user.Id);

        // Add sample listings
        var booksCategory = categories[0];
        var techCategory = categories[1];
        var furnitureCategory = categories[2];
        var clothingCategory = categories[3];

        var listings = new[]
        {
            new Listing
            {
                SellerId = user.Id,
                Title = "Calculus Textbook",
                Description = "Calculus: Early Transcendentals, used for one semester, good condition. No markings except highlighted key concepts.",
                Price = 45.00m,
                Category = booksCategory,
                Condition = ListingCondition.Good,
                Status = ListingStatus.Active,
                CreatedAt = DateTime.UtcNow.AddDays(-5),
                Images = new List<ListingImage> { new ListingImage { PathOrUrl = "https://picsum.photos/400/300?random=1" } }
            },
            new Listing
            {
                SellerId = user.Id,
                Title = "MacBook Pro 13\"",
                Description = "2019 MacBook Pro, 8GB RAM, 256GB SSD. Works perfectly, minor scratches on lid. Battery health 85%.",
                Price = 750.00m,
                Category = techCategory,
                Condition = ListingCondition.LikeNew,
                Status = ListingStatus.Active,
                CreatedAt = DateTime.UtcNow.AddDays(-10),
                Images = new List<ListingImage> { new ListingImage { PathOrUrl = "https://picsum.photos/400/300?random=2" } }
            },
            new Listing
            {
                SellerId = user.Id,
                Title = "Study Desk Chair",
                Description = "Ergonomic office chair, adjustable height, comfy padding. Good for long study sessions.",
                Price = 80.00m,
                Category = furnitureCategory,
                Condition = ListingCondition.Good,
                Status = ListingStatus.Active,
                CreatedAt = DateTime.UtcNow.AddDays(-3),
                Images = new List<ListingImage> { new ListingImage { PathOrUrl = "https://picsum.photos/400/300?random=3" } }
            },
            new Listing
            {
                SellerId = user.Id,
                Title = "Winter Jacket",
                Description = "North Face winter jacket, size M, very warm. Only wore it one season.",
                Price = 120.00m,
                Category = clothingCategory,
                Condition = ListingCondition.LikeNew,
                Status = ListingStatus.Active,
                CreatedAt = DateTime.UtcNow.AddDays(-7),
                Images = new List<ListingImage> { new ListingImage { PathOrUrl = "https://picsum.photos/400/300?random=4" } }
            },
            new Listing
            {
                SellerId = user.Id,
                Title = "Physics Lab Kit",
                Description = "Complete physics lab equipment from PHY 100 class. All items included, barely used.",
                Price = 35.00m,
                Category = categories[5], // Misc
                Condition = ListingCondition.LikeNew,
                Status = ListingStatus.Active,
                CreatedAt = DateTime.UtcNow.AddDays(-12),
                Images = new List<ListingImage> { new ListingImage { PathOrUrl = "https://picsum.photos/400/300?random=5" } }
            },
            new Listing
            {
                SellerId = user.Id,
                Title = "Organic Chemistry Textbook",
                Description = "Third edition, excellent condition. Great for OChem 1 and 2.",
                Price = 55.00m,
                Category = booksCategory,
                Condition = ListingCondition.Good,
                Status = ListingStatus.Active,
                CreatedAt = DateTime.UtcNow.AddDays(-6),
                Images = new List<ListingImage> { new ListingImage { PathOrUrl = "https://picsum.photos/400/300?random=6" } }
            },
            new Listing
            {
                SellerId = user.Id,
                Title = "iPad Air",
                Description = "2020 iPad Air, 64GB, space gray. Perfect for taking notes and watching lectures.",
                Price = 450.00m,
                Category = techCategory,
                Condition = ListingCondition.LikeNew,
                Status = ListingStatus.Active,
                CreatedAt = DateTime.UtcNow.AddDays(-4),
                Images = new List<ListingImage> { new ListingImage { PathOrUrl = "https://picsum.photos/400/300?random=7" } }
            },
            new Listing
            {
                SellerId = user.Id,
                Title = "Basketball Shoes",
                Description = "Nike basketball shoes, size 10.5, worn only a few times. Still have original box.",
                Price = 75.00m,
                Category = clothingCategory,
                Condition = ListingCondition.LikeNew,
                Status = ListingStatus.Active,
                CreatedAt = DateTime.UtcNow.AddDays(-8),
                Images = new List<ListingImage> { new ListingImage { PathOrUrl = "https://picsum.photos/400/300?random=8" } }
            },
            new Listing
            {
                SellerId = user.Id,
                Title = "Mini Fridge",
                Description = "Compact mini fridge for dorm room. Works great, just need it gone before moving out.",
                Price = 60.00m,
                Category = furnitureCategory,
                Condition = ListingCondition.Good,
                Status = ListingStatus.Active,
                CreatedAt = DateTime.UtcNow.AddDays(-2),
                Images = new List<ListingImage> { new ListingImage { PathOrUrl = "https://picsum.photos/400/300?random=9" } }
            },
            new Listing
            {
                SellerId = user.Id,
                Title = "Calculus Study Guide",
                Description = "Helpful study guide with practice problems and solutions. Got me an A!",
                Price = 15.00m,
                Category = booksCategory,
                Condition = ListingCondition.Good,
                Status = ListingStatus.Active,
                CreatedAt = DateTime.UtcNow.AddDays(-1),
                Images = new List<ListingImage> { new ListingImage { PathOrUrl = "https://picsum.photos/400/300?random=10" } }
            }
        };

            try
            {
                context.Listings.AddRange(listings);
                context.SaveChanges();
                logger?.LogInformation("Successfully added {Count} sample listings", listings.Length);
            }
            catch (Exception ex)
            {
                logger?.LogError(ex, "Error seeding listings");
            }
            
            logger?.LogInformation("Database seeding completed successfully");
        }
        catch (Exception ex)
        {
            logger?.LogError(ex, "Unhandled exception during database seeding");
        }
    }
}

