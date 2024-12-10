using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Car.Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string? FirstName { get; set; } = default!;
        public string? LastName { get; set; } = default!;
        public string? PIN { get; set; }
        public UserContactDetails? ContactDetails { get; set; } = default!;

        
 
        public ICollection<Car> Cars { get; set; } = new List<Car>();

        
        public ICollection<Repair> Repairs { get; set; } = new List<Repair>();

        
    }

}

