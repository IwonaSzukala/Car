/*using Car.MVC.Models; // Używaj odpowiedniego namespace
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Car.Domain.Entities;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Car.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<AccountController> _logger;

        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<AccountController> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = model.Input.Email,
                    Email = model.Input.Email,
                    FirstName = model.Input.FirstName,
                    LastName = model.Input.LastName,
                    PhoneNumber = model.Input.PhoneNumber,
                    ContactDetails = new UserContactDetails
                    {
                        Street = model.Input.Street,
                        City = model.Input.City,
                        PostalCode = model.Input.PostalCode
                    }
                };

                var result = await _userManager.CreateAsync(user, model.Input.Password);

                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var callbackUrl = Url.Action(
                        "ConfirmEmail", "Account",
                        new { userId = user.Id, code },
                        protocol: Request.Scheme);

                    // Możesz wysłać e-mail z linkiem potwierdzającym
                    // await _emailSender.SendEmailAsync(model.Input.Email, "Potwierdź swój email",
                    //    $"Kliknij w <a href='{callbackUrl}'>tutaj</a>, aby potwierdzić swój adres e-mail.");

                    await _signInManager.SignInAsync(user, isPersistent: false);

                    return RedirectToAction("Index", "Home"); // Zmien miejsce docelowe według swoich potrzeb
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // Jeśli rejestracja się nie udała, zwróć widok z błędami
            return View(model);
        }

        // Inne akcje jak logowanie, wylogowanie, potwierdzenie email itd.
    }
}
*/