using Travelitinerary.Shared.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Drawing;

namespace Travelitinerary.Server.Configurations.Entities
{
    public class FlightSeedConfigurations : IEntityTypeConfiguration<Flight>
    {
        public void Configure(EntityTypeBuilder<Flight> builder)
        {
            builder.HasData(
                new Flight
                {
                    Id = 1,
                    AirlineName = "Blue Airlines",
                    Arrival = "New York",
                    Departure = "Los Angeles",
                    Details = "Direct flight with in-flight entertainment",
                    WeekDay = "Monday",
                    CheckIn = DateTime.Parse("2024-01-17T12:00:00"),
                    SeatClass = "Business Class",
                    Availableseats = 50,
                    Price = 500.00f
                }
            );
        }
    }
}
