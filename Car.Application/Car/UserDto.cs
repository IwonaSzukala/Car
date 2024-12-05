using Car.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.Application.Car
{
    public class UserDto
    {
        public string Id { get; set; }

        public string? Username { get; set; } 
        
        public string? FirstName { get; set; }
        
        public string? LastName { get; set; } 
        public string? Email { get; set; } 
        
        public string? Password { get; set; } 
        
        public string? PhoneNumber { get; set; } 
        
        public string? Street { get; set; } 
       
        public string? City { get; set; } 
       
        public string? PostalCode { get; set; }
        public string? CreatedById { get; set; }
        public ApplicationUser? CreatedBy { get; set; } //sama to doda³am



    }
}
