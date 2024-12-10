using Car.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Car.Application.Car
{
    public class RepairDto
    {
        public int Id { get; set; }
        public int? CarId { get; set; }
        public string MechanicId { get; set; }
        public ApplicationUser? Mechanic { get; set; } 


        public DateTime? ReservationDate { get; set; }


        public string? Information { get; set; }

        public string Status { get; set; } = "Oczekiwanie";

        public bool IsEditable { get; set; }
        public bool IsVisible { get; set; } 

        public string? CreatedById { get; set; }
        public ApplicationUser? CreatedBy { get; set; } 

    }
}
