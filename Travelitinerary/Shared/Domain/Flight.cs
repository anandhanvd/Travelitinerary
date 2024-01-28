using System.ComponentModel.DataAnnotations;

namespace Travelitinerary.Shared.Domain
{
    public class Flight : BaseDomainModel
    {
        public string AirlineName{ get; set;}
        public string? Arrival { get; set; }
        public string? Departure { get; set; }
        public string? Details { get; set; }
        public string? WeekDay { get; set; }
        public DateTime? CheckIn { get; set; }
        public string? SeatClass { get; set; }
        public int? Availableseats { get; set; }
        public float? Price { get; set; }
        public virtual ICollection<Itinerary>? Itinerary { get; set;}
    }
}
