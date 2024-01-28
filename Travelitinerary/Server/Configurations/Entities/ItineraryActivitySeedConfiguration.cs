using Travelitinerary.Shared.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Drawing;

namespace Travelitinerary.Server.Configurations.Entities
{
    public class ItineraryActivitySeedConfiguration : IEntityTypeConfiguration<ItineraryActivity>
    {
        public void Configure(EntityTypeBuilder<ItineraryActivity> builder)
        {

        }
    }
}
