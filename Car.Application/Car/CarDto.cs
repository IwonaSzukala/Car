using Car.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.Application.Car
{
    public class CarDto
    {
        public int Id { get; set; }
        public string? UserId { get; set; } 

        public string? CarBrand { get; set; } 

        public string? CarModel { get; set; } 

        public string? ProductionYear { get; set; } 
       
        public string? RegistrationNumber { get; set; } 
       
        public string? VIN { get; set; }

        public ApplicationUser? User { get; set; }
        public bool IsEditable { get; set; }
        public bool IsVisible { get; set; } 

        public string? CreatedById { get; set; }
        public ApplicationUser? CreatedBy { get; set; } 

    }
}
