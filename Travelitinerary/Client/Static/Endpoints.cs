using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Travelitinerary.Client.Static
{
    public static class Endpoints
    {
        private static readonly string Prefix = "api";

        public static readonly string CustomerEndpoint = $"{Prefix}/customers";
        public static readonly string BookingEndpoint = $"{Prefix}/bookings";
        public static readonly string StaffEndpoint = $"{Prefix}/staffs";
        public static readonly string ItineraryEndpoint = $"{Prefix}/itineraries";
        public static readonly string HotelEndpoint = $"{Prefix}/hotels";
        public static readonly string FlightEndpoint = $"{Prefix}/flights";
        public static readonly string ItineraryActivityEndpoint = $"{Prefix}/itineraryactivies";
        public static readonly string ActivityEndpoint = $"{Prefix}/activies";


    }
}
