﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travelitinerary.Shared.Domain
{
    internal class Customer : BaseDomainModel
    {

        public string? Nationality { get; set; }
        public string? ContactNumber { get; set; }
        public string? EmailAddress { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Gender { get; set; }
        public string? Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public virtual List<Bookings>? Bookings { get; set; }
    }
}
