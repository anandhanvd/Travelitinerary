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
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime? DateCreated { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime? DateUpdated { get; set; } 
        [Required]
        public int no_of_days {  get; set; }
        [Required]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Please enter the package details.")]
        public string? PackaageDetails {  get; set; }
        public virtual Flight? Flight { get; set; }
        public virtual Hotel? Hotel { get; set; }
        public virtual Staff? Staff { get; set; }
        public virtual ICollection<ItineraryActivity>? ItineraryActivity {  get; set; }
    }
}
