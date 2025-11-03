# CampusSwap

A secure student-only marketplace where users log in with .edu email addresses to buy, sell, and message about items on campus.

## Features

- **Secure Authentication**: Only .edu email addresses can register
- **Browse Listings**: Search and filter by category
- **Create Listings**: Post items for sale with details
- **Messaging**: Communicate with sellers/buyers
- **Favorites**: Save listings you're interested in
- **Modern UI**: Built with MudBlazor components

## Tech Stack

- .NET 8
- Blazor Server
- Entity Framework Core + SQLite
- ASP.NET Identity
- MudBlazor

## Getting Started

### Prerequisites

- .NET 8 SDK
- Your favorite code editor (Visual Studio, VS Code, Rider)

### Setup

1. Clone or download this repository
2. Navigate to the CampusSwap directory:

   ```bash
   cd CampusSwap
   ```

3. Restore dependencies:

   ```bash
   dotnet restore
   ```

4. Run the application:

   ```bash
   dotnet run
   ```

5. Open your browser and navigate to:

   ```bash
   https://localhost:5001
   ```

### First Run

On first run, the application will:

- Create the SQLite database (`campusswap.db`)
- Seed 6 categories (Books, Tech, Furniture, Clothing, Tickets, Misc)
- Create 10 sample listings
- Create a test user: `student@liberty.edu` with password `Test123!`

### Registration

To register a new account:

1. Click "Register" in the navigation
2. Use a `.edu` email address (or ending with `@liberty.edu`)
3. Enter your campus name
4. Create a password (minimum 4 characters for demo purposes)

### Default Credentials

- **Email**: `student@liberty.edu`
- **Password**: `Test123!`

## Project Structure

```bash
CampusSwap/
├── Areas/
│   └── Identity/          # Authentication pages
├── Components/            # Reusable components
├── Data/                  # DbContext and seed data
├── Models/                # Entity models
├── Pages/                 # Blazor pages
│   ├── Home.razor         # Browse listings
│   ├── ListingDetail.razor
│   ├── NewListing.razor
│   ├── MyListings.razor
│   ├── Messages.razor
│   └── Favorites.razor
├── Shared/                # Shared layouts
└── wwwroot/               # Static files
```

## Business Rules

- Users can only edit/delete their own listings
- Sold listings are hidden from the browse page
- Listings must have a price greater than 0
- Only authenticated users can create listings, send messages, and favorite items
- Browse page is accessible to everyone

## Future Enhancements

- [ ] Real image upload functionality
- [ ] Pagination or infinite scroll
- [ ] Admin page to manage reports
- [ ] URL search parameter persistence
- [ ] Export listings to CSV
- [ ] Email notifications for new messages
- [ ] Advanced search and filters

## License

This project is created for educational purposes.

---
**Note**: This is a demo application with no real payment processing. It's designed for learning and demonstration purposes only.
