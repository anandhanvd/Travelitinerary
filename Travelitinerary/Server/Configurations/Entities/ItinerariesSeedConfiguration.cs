using Travelitinerary.Shared.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Drawing;

namespace Travelitinerary.Server.Configurations.Entities
{
    public class ItinerariesSeedConfiguration : IEntityTypeConfiguration<Itinerary>
    {
        public void Configure(EntityTypeBuilder<Itinerary> builder)
        {
            builder.HasData(
                new Itinerary
                {
                    Id = 1,
                    DateCreated = DateTime.Parse("2024-01-20T11:00:00"),
                    CreatedBy = "Kevin Tong",
                    DateUpdated = DateTime.Parse("2024-01-25T11:00:00"),
                    no_of_days = 3,
                    PackaageDetails = "Double Bedroom, Sea facing room",
                    UpdatedBy = "Arthur",
                    Staff = new Staff
                    {
                        Id = 1,
                        FirstName = "Kevin",
                        LastName = "Tong",
                        Email = "tonggiakhanh.kevin@gmail.com",
                        Phone = "886643347",
                        Address = "Temasek Poly",
                        DateOfBirth = new DateTime(2004, 1, 5),
                        HireDate = new DateTime(2023, 12, 1),
                        Position = "assistant",
                        Gender = "Male"
                    },
                    Flights = new Flight 
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
                    },
                    Hotels = new Hotel
                    {
                        Id = 1,
                        Name = "Grand Hotel",
                        Address = "Paris",
                        Details = "Luxurious hotel with spa and scenic view",
                        CheckOut = DateTime.Parse("2024-01-20T11:00:00"),
                        CheckIn = DateTime.Parse("2024-01-17T14:00:00"),
                        RoomType = "Deluxe Suite",
                        Price = 300.00f
                    }
                }
                );
        }
    }
}
