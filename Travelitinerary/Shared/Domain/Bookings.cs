using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travelitinerary.Shared.Domain
{
    internal class Bookings : BaseDomainModel
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? BookType { get; set; }
        public string? BookTitle { get; set; }
        public string? BookDescription { get; set; }
        public int ItineraryID { get; set; }
        public int CustomerID { get; set; }
        public virtual Customer? Customer { get; set; }
        public int AvailableSlots { get; set; }
    }
}
