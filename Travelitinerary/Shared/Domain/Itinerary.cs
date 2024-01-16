using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travelitinerary.Shared.Domain
{
    public class Itinerary : BaseDomainModel
    {
        public int no_of_days {  get; set; }
        public string? PackaageDetails {  get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated {  get; set; }
        public virtual Flight? Flights { get; set; }
        public virtual Hotel? Hotels { get; set; }
        public virtual Staff? Staff { get; set; }
    }
}
