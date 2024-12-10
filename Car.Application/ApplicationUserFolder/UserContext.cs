using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Car.Domain.Entities;
using Car.Application.ApplicationUserFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Car.Application.ApplicationUserFolder
{
    public interface IUserContext
    {
        CurrentUser? GetCurrentUser();
    }

    public class UserContext : IUserContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserContext(IHttpContextAccessor httpContextAccessor, UserManager<ApplicationUser> userManager)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }

        public CurrentUser? GetCurrentUser()
        {
            var user = _httpContextAccessor?.HttpContext?.User;
            if (user == null || user.Identity == null || !user.Identity.IsAuthenticated)
            {
                return null;
            }

            var id = user.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            var email = user.FindFirst(c => c.Type == ClaimTypes.Email)?.Value;
            var roles = user.Claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value);

            var applicationUser =  _userManager.FindByIdAsync(id).Result;
            if (applicationUser == null)
            {
                throw new InvalidOperationException("User not found.");
            }
            var contactDetails = applicationUser.ContactDetails;

            return new CurrentUser(
                id,
                email,
                roles,
                applicationUser.FirstName,
                applicationUser.LastName,
                contactDetails?.PhoneNumber,
                contactDetails?.Street,
                contactDetails?.City,
                contactDetails?.PostalCode
            );
        }
    }
}
