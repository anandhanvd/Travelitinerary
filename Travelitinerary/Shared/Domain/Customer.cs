using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Travelitinerary.Shared.Domain
{
    public class Customer : BaseDomainModel
    {
        [Required(ErrorMessage = "Nationality is required.")]
        public string? Nationality { get; set; }

        [Required(ErrorMessage = "Contact Number is required.")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"(6|8|9)\d{7}", ErrorMessage = "Contact Number is not a valid phone number")]
        public string? ContactNumber { get; set; }

        [Required(ErrorMessage = "Email Address is required.")]
        [EmailAddress(ErrorMessage = "Email Address is not a valid email.")]
        public string? EmailAddress { get; set; }

        [Required(ErrorMessage = "First Name is required.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "First name does not meet length requirement.")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "First name does not meet length requirement.")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "Gender is required.")]
        public string? Gender { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        public string? Address { get; set; }

        [Required(ErrorMessage = "Date of Birth is required.")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        public virtual List<Booking>? Bookings { get; set; }
    }
}
