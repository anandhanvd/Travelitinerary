
using Travelitinerary.Shared.Domain;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Travelitinerary.Server.IRepository

{
    public interface IUnitOfWork : IDisposable
    {

        Task Save(HttpContext httpContext);
        IGenericRepository<Flight> Flights { get; }
        IGenericRepository<Staff> Staffs { get; }
        IGenericRepository<Hotel> Hotels { get; }
        IGenericRepository<Activity> Activities { get; }
        IGenericRepository<Itinerary> Itineraries { get; }
        IGenericRepository<Booking> Bookings { get; }
        IGenericRepository<Customer> Customers { get; }
        
        IGenericRepository<ItineraryActivity> ItineraryActivities { get; }
    }
}