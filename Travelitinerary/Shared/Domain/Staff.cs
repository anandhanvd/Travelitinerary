using System.ComponentModel.DataAnnotations;

namespace Travelitinerary.Shared.Domain
{
    public class Staff : BaseDomainModel
    {
        public string? FirstName { get; set; }
        public string? LastName{ get; set; }
        public string? Email { get; set; }
        public string? Phone {  get; set; }
        public string? Address {  get; set; }
        [Required]
        public DateTime DateOfBirth {  get; set; }
        [Required]
        public DateTime HireDate { get; set; }
        public string? Position { get; set; }
        public string? Gender { get; set; }
        public virtual ICollection<Itinerary>? Itinerary { get; set; }

    }
}
