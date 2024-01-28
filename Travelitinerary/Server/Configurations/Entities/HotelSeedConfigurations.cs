using Travelitinerary.Shared.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Drawing;

namespace Travelitinerary.Server.Configurations.Entities
{
    public class HotelSeedConfigurations : IEntityTypeConfiguration<Hotel>
    {
        public void Configure(EntityTypeBuilder<Hotel> builder)
        {
            builder.HasData(
                new Hotel
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
            );
        }
    }
}
