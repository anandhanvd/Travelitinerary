using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Travelitinerary.Client.Pages;
using Travelitinerary.Server.Configurations.Entities;
using Travelitinerary.Server.Models;
using Travelitinerary.Shared.Domain;

namespace Travelitinerary.Server.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        public DbSet<Flight> Flights { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Itinerary> Itineraries { get; set; }
        public DbSet<ItineraryActivity> ItineraryActivities { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Activity> Activities { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new FlightSeedConfigurations());
            builder.ApplyConfiguration(new HotelSeedConfigurations());
            builder.ApplyConfiguration(new StaffSeedConfiguration());
            builder.ApplyConfiguration(new ActivitySeedConfiguration());
            builder.ApplyConfiguration(new ItinerariesSeedConfiguration());
            builder.ApplyConfiguration(new ItineraryActivitySeedConfiguration());
        }
    }
}
