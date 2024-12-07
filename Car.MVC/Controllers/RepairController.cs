using AutoMapper;
using Car.Application.Car;
using Car.Application.Car.Commands.CreateCar;
using Car.Application.Car.Commands.CreateRepair;
using Car.Application.Car.Commands.CreateUser;
using Car.Application.Car.Commands.EditCar;
using Car.Application.Car.Queries.GetAllCars;
using Car.Application.Car.Queries.GetAllRepairs;
using Car.Application.Car.Queries.GetById;
using Car.Application.Car.Queries.GetByUsername;
using Car.Application.Car.Queries.GetCarsByUserId;
using Car.Application.Car.Queries.GetUserWithMechanicRole;
using Car.Domain.Entities;
using Car.MVC.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Car.MVC.Controllers

{
    public class RepairController : Controller
    {
        //private readonly IRepairService _repairService;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public RepairController(IMediator mediator, IMapper mapper)
        {
            //_repairService = repairService;
            _mapper = mapper;
            _mediator = mediator;
        }

        [Authorize]
        public async Task<IActionResult> Create()
        {
            var model = new CreateRepairViewModel
            {
                Cars = await (_mediator.Send(new GetCarsByUserIdQuery(User.FindFirstValue(System.Security.Claims.ClaimTypes.NameIdentifier)))),
                Mechanics = await _mediator.Send(new GetUserWithMechanicRoleQuery()),
                CreateRepairCommand = new CreateRepairCommand(),
            };
            return View(model);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreateRepairViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            await _mediator.Send(model.CreateRepairCommand);
            return RedirectToAction(nameof(Create)); //todo
        }

        [HttpPost]
        [Authorize(Roles = "Mechanic, Admin")]
        [Route("Repair/{id}/Edit")]
        public async Task<IActionResult> Edit(int id, EditRepairCommand command)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }
            await _mediator.Send(command);
            return RedirectToAction(nameof(Index)); //todo
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var repairs = await _mediator.Send(new GetAllRepairsQuery());
            return View(repairs);
        }

        [Authorize]
        [Route("Repair/List/{username}")]
        public async Task<IActionResult> ShowByUsername(string username)
        {
            
            var repairs = await _mediator.Send(new GetRepairsByUsernameQuery(username));
            return View(repairs);
        }

        [Authorize(Roles = "Mechanic, Admin")]
        [Route("Repair/{id}/Edit")]
        public async Task<IActionResult> Edit(int id)
        {
            
            var dto = await _mediator.Send(new GetRepairByIdQuery(id));


            /*if (!dto.IsEditable)
            {
                return RedirectToAction("NoAccess", "Home");
            }*/

            /*if (!dto.IsVisible)
            {
                return RedirectToAction("NoAccess", "Home");
            }*/ //BO WTEDY NIE DZIA£A ZMIANA DLA ADMINA

            EditRepairCommand model = _mapper.Map<EditRepairCommand>(dto);

            return View(model);
        }


    }
}
