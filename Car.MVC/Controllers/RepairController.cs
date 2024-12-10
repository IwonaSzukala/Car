using AutoMapper;
using Car.Application.ApplicationUserFolder;
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
using Car.Application.Car.Queries.GetRepairByUserId;
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
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IUserContext _userContext;

        public RepairController(IMediator mediator, IMapper mapper)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [Authorize]
        public async Task<IActionResult> Create()
        {
            var model = new CreateRepairViewModel
            {
                Cars = await _mediator.Send(new GetCarsByUserIdQuery(User.FindFirstValue(ClaimTypes.NameIdentifier))),
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
            return RedirectToAction(nameof(Index));
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
            return RedirectToAction(nameof(Index));
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var repairs = await _mediator.Send(new GetRepairByUserIdQuery(userId));
            return View(repairs);
        }

        [Authorize(Roles = "Mechanic, Admin")]
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
            EditRepairCommand model = _mapper.Map<EditRepairCommand>(dto);
            return View(model);
        }
    }
}
