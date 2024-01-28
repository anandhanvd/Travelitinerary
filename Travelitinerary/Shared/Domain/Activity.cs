using System.ComponentModel.DataAnnotations;

namespace Travelitinerary.Shared.Domain
{
    public class Activity : BaseDomainModel
    {
        [Required]
        public string Name { get; set; }
        public string? Type { get; set; }
        public DateTime? TimeStart { get; set; }
        public DateTime? TimeEnd { get; set; }
        public float Duration { get; set; }
        [Required]
        public float Price { get; set; }
        public string? Description { get; set; }
        public byte[]? ActivityImage { get; set; }
        public virtual ICollection<ItineraryActivity>? ItineraryActivity { get; set; }
    }
}
