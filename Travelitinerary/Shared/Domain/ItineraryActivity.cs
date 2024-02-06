using System.ComponentModel.DataAnnotations;

namespace Travelitinerary.Shared.Domain
{
    public class ItineraryActivity : BaseDomainModel
    {
        public int? ItineraryId { get; set; }
        [Required]
        public int ActivityId { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DateScheduled { get; set; } = DateTime.Now;
        public virtual Itinerary? Itinerary { get; set; }
        public virtual Activity? Activity { get; set; }
    }
}
