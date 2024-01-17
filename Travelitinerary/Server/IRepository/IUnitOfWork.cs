using System.Diagnostics;
using Travelitinerary.Shared.Domain;

namespace Travelitinerary.Server.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        Task Save(HttpContext httpContext);
        IGenericRepository<Flight> Flight { get; }
        IGenericRepository<Hotel> Hotel { get; }
        IGenericRepository<Activity> Activities { get; }
        IGenericRepository<Itinerary> Itinerary { get; }
        IGenericRepository<Booking> Bookings { get; }
        IGenericRepository<Customer> Customers { get; }
        IGenericRepository<Staff> Staff { get; }
        IGenericRepository<ItineraryActivity> ItineraryActivities { get; }

    }
}