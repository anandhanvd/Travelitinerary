using System;
using System.ComponentModel.DataAnnotations;

namespace Travelitinerary.Shared.Domain
{
    public class Booking : BaseDomainModel
    {
        [Required(ErrorMessage = "Start Date is required.")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "End Date is required.")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "Book Type is required.")]
        public string? BookType { get; set; }

        [Required(ErrorMessage = "Book Title is required.")]
        public string? BookTitle { get; set; }

        [Required(ErrorMessage = "Book Description is required.")]
        public string? BookDescription { get; set; }

        [Required(ErrorMessage = "Itinerary ID is required.")]
        public int ItineraryID { get; set; }

        public virtual Itinerary? Itinerary { get; set; }

        [Required(ErrorMessage = "Customer ID is required.")]
        public int CustomerID { get; set; }

        public virtual Customer? Customer { get; set; }

        [Required(ErrorMessage = "Available Slots is required.")]
        [Range(0, int.MaxValue, ErrorMessage = "Available Slots must be a non-negative value.")]
        public int AvailableSlots { get; set; }
    }
}
