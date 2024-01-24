using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Drawing;
using Travelitinerary.Shared.Domain;

namespace Travelitinerary.Server.Configurations.Entities
{
    public class StaffSeedConfiguration : IEntityTypeConfiguration<Staff>
    {
        public void Configure(EntityTypeBuilder<Staff> builder)
        {
            builder.HasData(
                new Staff
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

                new Staff
                {
                    Id = 2,
                    FirstName = "Anand",
                    Address = "Temasek Poly",
                    HireDate = new DateTime(2023, 12, 1),
                    Position = "assistant",
                    Gender = "Male"
                }
        );
        }
    }
}
