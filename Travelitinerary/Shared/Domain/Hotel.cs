﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travelitinerary.Shared.Domain
{
    public  class Hotel : BaseDomainModel
    {
        
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Details { get; set; }
        public DateTime CheckOut { get; set; }
        public DateTime? CheckIn { get; set; }
        public string? RoomType { get; set; }
        public float Price { get; set; }

    }

}

