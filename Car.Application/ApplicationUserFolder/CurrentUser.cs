using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Car.Application.ApplicationUserFolder
{
    public class CurrentUser
    {
        public CurrentUser(string id, string email, IEnumerable<string> roles, string firstName, string lastName, string phoneNumber, string street, string city, string postalCode)
        {
            Id = id;
            Email = email;
            Roles = roles;
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Street = street;
            City = city;
            PostalCode = postalCode;
        }

        public string Id { get; set; }
        public string Email { get; set; }
        public IEnumerable<string> Roles { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }

        public bool IsInRole(string role) => Roles.Contains(role);
    }
}

