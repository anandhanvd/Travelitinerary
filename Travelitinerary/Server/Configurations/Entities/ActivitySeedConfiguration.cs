using Travelitinerary.Shared.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Drawing;

namespace Travelitinerary.Server.Configurations.Entities
{
    public class ActivitySeedConfiguration : IEntityTypeConfiguration<Activity>
    {
        public void Configure(EntityTypeBuilder<Activity> builder)
        {
            builder.HasData(
                new Activity
                {
                    Id = 1,
                    DateCreated = DateTime.Parse("2024-01-20T11:00:00"),
                    CreatedBy = "Kevin Tong",
                    DateUpdated = DateTime.Parse("2024-01-25T11:00:00"),
                    UpdatedBy = "Arthur",
                    Description = "Room Cleaning",
                    Duration = 4f,
                    Name = "Kevin",
                    Price = 56.00f,
                    TimeStart = DateTime.Now,
                    TimeEnd = DateTime.Now.AddHours(6),
                    Type = "Cleaning"
                }
            );
        }
    }
}
