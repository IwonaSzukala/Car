using AutoMapper;
using Car.Application.Car;
using Car.Application.Car.Commands.CreateCar;
using Car.Application.Car.Commands.EditCar;
using Car.Application.Car.Queries.GetAllCars;
using Car.Application.Car.Queries.GetById;
using Car.Application.Car.Queries.GetByUsername;
using Car.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Car.MVC.Controllers

{
    public class CarController : Controller 
    {
        //private readonly IUserService _userService;
        //private readonly ICarService _carService;

        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public CarController(IMediator mediator, IMapper mapper) 
        {
            //_carService= carService;
            _mediator = mediator;
            _mapper = mapper;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var cars = await _mediator.Send(new GetAllCarsQuery());
            return View(cars);
        }

        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreateCarCommand command)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }
            //var userId = car.UserId;
            //User user = await _userService.GetUserByIdAsync(userId);
            //car.User= user;

            await _mediator.Send(command);
            return RedirectToAction(nameof(Index)); //todo
        }

        [HttpPost]
        [Authorize]
        [Route("Car/{id}/Edit")]
        public async Task<IActionResult> Edit(int id, EditCarCommand command)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }

            //var userId = car.UserId;
            //User user = await _userService.GetUserByIdAsync(userId);
            //car.User= user;
            await _mediator.Send(command);
            return RedirectToAction(nameof(Index)); //todo
        }

        [Authorize]
        [Route("Car/{id}/Edit")]
        public async Task<IActionResult> Edit(int id)
        {
           
            var dto = await _mediator.Send(new GetCarByIdQuery(id));

            if (!dto.IsEditable)
            {
                return RedirectToAction("NoAccess", "Home");
            }

            if (!dto.IsVisible)
            {
                return RedirectToAction("NoAccess", "Home");
            }

            EditCarCommand model = _mapper.Map<EditCarCommand>(dto);
            
            return View(model);
        }
    }
}


