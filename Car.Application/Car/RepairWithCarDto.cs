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

        
        public DateTime ReservationDate { get; set; } = DateTime.UtcNow;

        public ApplicationUser? Mechanic { get; set; } 
        
        public string? Information { get; set; }

        public string Status { get; set; } = "Oczekiwanie";
        

        public bool IsEditable { get; set; }
        public bool IsVisible { get; set; } 
        public Domain.Entities.Car? Car { get; set; } = default!;

        public string? CreatedById { get; set; }
        public ApplicationUser? CreatedBy { get; set; } 

    }
}
