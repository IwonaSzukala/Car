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
using Microsoft.AspNetCore.Mvc;

namespace Car.MVC.Controllers

{
    public class UserController : Controller
    {
        //private readonly IUserService _userService;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public UserController(IMediator mediator, IMapper mapper)
        {
            //_userService = userService;
            _mediator = mediator;
            _mapper = mapper;
        }

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
            var dto = await _mediator.Send(new GetCarsByUsernameQuery(username));   
            return View(dto);
        }

        //[Route("User/{username}/Edit")]
        //public async Task<IActionResult> Edit(string username)
        //{
        //    var dto = await _mediator.Send(new GetCarsByUsernameQuery(username));
        //    return View(dto);
        //}

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserCommand command)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }
            await _mediator.Send(command);
            return RedirectToAction(nameof(Create)); //todo
        }

        [HttpPost]
        [Route("User/{id}/Edit")]
        public async Task<IActionResult> Edit(int id, EditUserCommand command)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }
            await _mediator.Send(command);
            return RedirectToAction(nameof(Index)); //todo
        }

        /*[Route("User/{id}/Edit")]
        public async Task<IActionResult> Edit(int id)
        {
            var dto = await _mediator.Send(new GetUserByIdQuery(id));

            EditUserCommand model = _mapper.Map<EditUserCommand>(dto);

            return View(model);
        }*/
        [Route("User/{id}/Edit")]
        public async Task<IActionResult> Edit(string id)
        {
            var dto = await _mediator.Send(new GetUserByIdQuery(id));

            if (dto == null)
            {
                return NotFound();  // U¿ytkownik nie znaleziony
            }

            EditUserCommand model = _mapper.Map<EditUserCommand>(dto);

            // Dodaj logowanie lub breakpoint
            Console.WriteLine($"User DTO: {dto.Username}, {dto.Email}");

            return View(model);
        }

        [Route("User/{username}/Repairs")]
        public async Task<IActionResult> UsernameRepairs(string username)
        {
            var dto = await _mediator.Send(new GetRepairsByUsernameQuery(username));

            return View(dto);
        }
    }
}
