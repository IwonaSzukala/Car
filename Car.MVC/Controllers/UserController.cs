using AutoMapper;
using Car.Application.Car;
using Car.Application.Car.Commands.CreateCar;
using Car.Application.Car.Commands.CreateUser;
using Car.Application.Car.Commands.EditCar;
using Car.Application.Car.Queries.GetAllCars;
using Car.Application.Car.Queries.GetAllUsers;
using Car.Application.Car.Queries.GetById;
using Car.Application.Car.Queries.GetByUsername;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Car.MVC.Controllers

{
    public class UserController : Controller
    {
        
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public UserController(IMediator mediator, IMapper mapper)
        {
            
            _mediator = mediator;
            _mapper = mapper;
        }

        [Authorize(Roles = "Mechanic, Admin")]
        public async Task<IActionResult> Index()
        {
            var users = await _mediator.Send(new GetAllUsersQuery());
            return View(users);
        }


        public IActionResult Create()
        {

            return View();
        }

        

        [Route("User/{username}/Cars")]
        public async Task<IActionResult> Details(string username)
        {
            var carDto = await _mediator.Send(new GetCarsByUsernameQuery(username));

            if (carDto == null)
            {
                ViewBag.Message = "U¿ytkownik nie posiada ¿adnych samochodów.";
                return View(); 
            }

            return View(carDto); 
        }


       

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserCommand command)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }
            await _mediator.Send(command);
            return RedirectToAction(nameof(Create)); 
        }

        [HttpPost]
        [Route("User/{id}/Edit")]
        [Authorize(Roles = "Mechanic, Admin")]
        public async Task<IActionResult> Edit(int id, EditUserCommand command)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }
            await _mediator.Send(command);
            return RedirectToAction(nameof(Index)); 
        }

       
        [Route("User/{id}/Edit")]
        [Authorize(Roles = "Mechanic, Admin")]
        public async Task<IActionResult> Edit(string id)
        {
            var dto = await _mediator.Send(new GetUserByIdQuery(id));

            if (dto == null)
            {
                return NotFound();  
            }

            EditUserCommand model = _mapper.Map<EditUserCommand>(dto);

            
            Console.WriteLine($"User DTO: {dto.Username}, {dto.Email}");

            return View(model);
        }

        [Route("User/{username}/Repairs")]
        public async Task<IActionResult> UsernameRepairs(string username)
        {
            var dto = await _mediator.Send(new GetRepairsByUsernameQuery(username));

            return View(dto);
            /*var dto = await _mediator.Send(new GetRepairsByUsernameQuery(username));

            if (dto == null)
            {
                ViewBag.Message = "U¿ytkownik nie posiada ¿adnych napraw";
                return View(); // Wyœwietl widok z odpowiednim komunikatem.
            }

            return View(dto); // Jeœli jest samochód, zwróæ go do widoku.*/
        }
    }
}
