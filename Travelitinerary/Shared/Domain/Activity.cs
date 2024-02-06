using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Travelitinerary.Shared.Domain
{
    public class Activity : BaseDomainModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string? Type { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime? TimeStart { get; set; } = DateTime.Now;
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime? TimeEnd { get; set; } = DateTime.Now;
        public float Duration { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public float Price { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Please enter the description.")]
        public string? Description { get; set; }
        public byte[]? ActivityImage { get; set; }
        public virtual ICollection<ItineraryActivity>? ItineraryActivity { get; set; }
    }
}
