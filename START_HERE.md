# CampusSwap - Quick Start Guide

## What Was Created

This is a complete Blazor Server application with the following structure:

### Core Files
- `Program.cs` - Application startup and configuration
- `App.razor` - Root Blazor app component
- `_Imports.razor` - Global namespace imports
- `_Host.cshtml` - Razor page host
- `appsettings.json` - Configuration
- `CampusSwap.csproj` - Project file with dependencies

### Models (Data Layer)
- `AppUser.cs` - Extended Identity user with Campus property
- `Category.cs` - Product categories
- `Listing.cs` - Main listing entity
- `ListingImage.cs` - Listing images (placeholder URLs)
- `MessageThread.cs` - Message conversation threads
- `Message.cs` - Individual messages
- `Favorite.cs` - User favorites (composite key)
- `Report.cs` - Listing reports
- `Enums.cs` - Condition, Status, ReportStatus enums

### Data Layer
- `AppDbContext.cs` - Entity Framework DbContext with relationships
- `SeedData.cs` - Seeds 6 categories, test user, and 10 sample listings

### Pages
- `Home.razor` - Browse listings with search and category filters
- `ListingDetail.razor` - View listing details, message seller, favorite, report
- `NewListing.razor` - Create new listings
- `MyListings.razor` - Manage your own listings (edit, delete, mark sold)
- `Messages.razor` - View and send messages
- `Favorites.razor` - View favorited listings

### Components
- `MainLayout.razor` - Navigation bar with drawer, theme toggle
- `ReportDialog.razor` - Dialog for reporting listings

### Authentication
- `Areas/Identity/Pages/Account/Register.cshtml` - Registration with .edu email validation
- `Areas/Identity/Pages/Account/Login.cshtml` - Login page

## How to Run

```powershell
# Navigate to the CampusSwap directory
cd CampusSwap

# Restore packages
dotnet restore

# Run the application
dotnet run
```

The app will:
1. Create SQLite database (campusswap.db)
2. Seed 6 categories
3. Create test user (student@liberty.edu / Test123!)
4. Add 10 sample listings
5. Start on https://localhost:5001 (or similar)

## Default Credentials
- **Email**: student@liberty.edu
- **Password**: Test123!

## Features Implemented

✅ Authentication with .edu email validation  
✅ Browse listings with search and category filters  
✅ Create, edit, delete listings  
✅ Message sellers  
✅ Favorite listings  
✅ Report listings  
✅ KPI cards (Active Listings, Categories, Users)  
✅ Dark mode toggle  
✅ Responsive MudBlazor UI  

## Project Structure

```
CampusSwap/
├── Areas/Identity/          # Authentication pages
├── Components/             # ReportDialog
├── Data/                   # DbContext and SeedData
├── Models/                 # Entity models
├── Pages/                  # Blazor pages
├── Shared/                 # MainLayout
├── wwwroot/               # Static files (CSS, JS)
├── Program.cs
├── App.razor
└── CampusSwap.csproj
```

## Notes
- No file upload yet - uses Picsum placeholder images
- No real payment processing
- Uses MudBlazor for modern UI
- EF Core with SQLite (database file: campusswap.db)

Enjoy exploring CampusSwap!

