﻿
using Travelitinerary.Server.Data;
using Travelitinerary.Server.IRepository;
using Travelitinerary.Server.Models;
using Travelitinerary.Shared.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Travelitinerary.Server.Repository

{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        private IGenericRepository<Flight> _flights;

        private IGenericRepository<Hotel> _hotels;
             
        private IGenericRepository<Itinerary> _itineraries;

        private IGenericRepository<Booking> _bookings;

        private IGenericRepository<Customer> _customers;

        private IGenericRepository<Staff> _staffs;

        private IGenericRepository<Activity> _activities;

        private IGenericRepository<ItineraryActivity> _itineararyActivities;

        private UserManager<ApplicationUser> _userManager;
        public UnitOfWork(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IGenericRepository<Flight> Flights
                         => _flights ??= new GenericRepository<Flight>(_context);
        public IGenericRepository<Hotel> Hotels
            => _hotels ??= new GenericRepository<Hotel>(_context);
        public IGenericRepository<Itinerary> Itineraries
            => _itineraries ??= new GenericRepository<Itinerary>(_context);
        public IGenericRepository<Staff> Staffs
            => _staffs ??= new GenericRepository<Staff>(_context);
        public IGenericRepository<Booking> Bookings
            => _bookings ??= new GenericRepository<Booking>(_context);
        public IGenericRepository<Customer> Customers
            => _customers ??= new GenericRepository<Customer>(_context);
        public IGenericRepository<Activity> Activities
            => _activities ??= new GenericRepository<Activity>(_context);
        public IGenericRepository<ItineraryActivity> ItineraryActivities
            => _itineararyActivities ??= new GenericRepository<ItineraryActivity>(_context);

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save(HttpContext httpContext)
        {
            //To be implemented
            string user = "System";

            var entries = _context.ChangeTracker.Entries()
                .Where(q => q.State == EntityState.Modified ||
                    q.State == EntityState.Added);

            foreach (var entry in entries)
            {
                ((BaseDomainModel)entry.Entity).DateUpdated = DateTime.Now;
                ((BaseDomainModel)entry.Entity).UpdatedBy = user;
                if (entry.State == EntityState.Added)
                {
                    ((BaseDomainModel)entry.Entity).DateCreated = DateTime.Now;
                    ((BaseDomainModel)entry.Entity).CreatedBy = user;
                }
            }

            await _context.SaveChangesAsync();
        }
    }
}