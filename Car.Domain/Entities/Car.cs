using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.Domain.Entities
{
    public class Car
    {
        public int Id { get; set; }
        public string CarBrand { get; set; } = default!;
        public string CarModel { get; set; } = default!;
        public string ProductionYear { get; set; } = default!;
        public string RegistrationNumber { get; set; } = default!;
        public string VIN { get; set; } = default!;
        public string? CreatedById { get; set; }
        public ApplicationUser? CreatedBy { get; set; }                                                    
        public string? UserId { get; set; } 
        public ApplicationUser User { get; set; } = default!;
        public ICollection<Repair> Repair { get; set; } = new List<Repair>();
    }


}
