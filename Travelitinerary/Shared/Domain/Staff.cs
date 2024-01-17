using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travelitinerary.Shared.Domain
{
    public class Staff : BaseDomainModel
    {
        public string? FirstName { get; set; }

        public string? LastName{ get; set; }
        public string? Email { get; set; }
        public string? Phone {  get; set; }
        public string? Address {  get; set; }
        public DateTime DateOfBirth {  get; set; }
        public DateTime HireDate { get; set; }
        public string? Position { get; set; }
        public string? Gender { get; set; }

    }
}
