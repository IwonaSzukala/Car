using AutoMapper;
using Car.Application.Car;
using Car.Application.Car.Commands.CreateCar;
using Car.Application.Car.Commands.DeleteCar;
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
        
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public CarController(IMediator mediator, IMapper mapper) 
        {
            
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
            

            await _mediator.Send(command);
            return RedirectToAction(nameof(Index)); 
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

            
            await _mediator.Send(command);
            return RedirectToAction(nameof(Index)); 
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

        [HttpPost]
        [Authorize]
        [Route("Car/{id}/Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteCarCommand { Id = id });
            return RedirectToAction(nameof(Index));
        }
    }
}


