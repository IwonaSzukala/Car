using Car.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Car.Application.Car
{
    public class RepairWithCarDto
    {
        public int Id { get; set; }
        public string? CarId { get; set; }

        public string CarBrand { get; set; } = default!;
        public string CarModel { get; set; } = default!;
        public string MechanicId { get; set; }

        //[Required]
        public DateTime ReservationDate { get; set; } = DateTime.UtcNow;

        public ApplicationUser? Mechanic { get; set; } //doda³am to
        //[Required]
        public string? Information { get; set; }

        public string Status { get; set; } = "Oczekiwanie";
        //public string Status { get; set; } = default!; TAK SAMO JAK MA PODAC STATUS?

        // Nawigacja do mechanika
        //public User Mechanic { get; set; } = default!;

        //Nawigacja do samochodu

        public bool IsEditable { get; set; }
        public bool IsVisible { get; set; } //czy jest wyœwietlane, to ja sama zrobi³am
        public Domain.Entities.Car? Car { get; set; } = default!;

        public string? CreatedById { get; set; }
        public ApplicationUser? CreatedBy { get; set; } //sama to doda³am

    }
}
