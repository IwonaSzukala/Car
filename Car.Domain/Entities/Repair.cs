﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.Domain.Entities
{
    public class Repair
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public string MechanicId { get; set; }
        public DateTime ReservationDate { get; set; } = DateTime.UtcNow;
        public string Information { get; set; } = default!;
        public string Status { get; set; } = "Oczekiwanie";

        public string? CreatedById { get; set; }
        public ApplicationUser? CreatedBy { get; set; } //zamieniłam z identityuser

        // Nawigacja do mechanika
        public ApplicationUser Mechanic { get; set; } = default!;

        // Nawigacja do samochodu
        public Car Car { get; set; } = default!;
    }

}