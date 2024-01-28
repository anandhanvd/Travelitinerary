using System.ComponentModel.DataAnnotations;

namespace Travelitinerary.Shared.Domain
{
    public class Itinerary : BaseDomainModel
    {
        [Required]
        public int StaffId { get; set; }
        [Required]
        public int HotelId { get; set; }
        public int? FlightId { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        [Required]
        public int no_of_days {  get; set; }
        public string? PackaageDetails {  get; set; }
        public virtual Flight? Flight { get; set; }
        public virtual Hotel? Hotel { get; set; }
        public virtual Staff? Staff { get; set; }
        public virtual ICollection<ItineraryActivity>? ItineraryActivity {  get; set; }
    }
}
