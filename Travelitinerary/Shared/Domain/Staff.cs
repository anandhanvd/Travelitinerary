using System;
using System.ComponentModel.DataAnnotations;

namespace Travelitinerary.Shared.Domain
{
    public class Staff : BaseDomainModel
    {
        [Required]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "First name does not meet length requirement.")]
        public string? FirstName { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "First name does not meet length requirement.")]
        public string? LastName{ get; set; }
        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email Address is not a valid email")]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"(6|8|9)\d{7}", ErrorMessage = "Contact Number is not a valid phone number")]
        public string? Phone {  get; set; }
        
        public string? Address {  get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; } = DateTime.Now;
        [Required]
        public DateTime HireDate { get; set; } = DateTime.Now;
        [Required]
        public string? Position { get; set; }
        [Required]
        public string? Gender { get; set; }
        public virtual ICollection<Itinerary>? Itinerary { get; set; }

    }
}
