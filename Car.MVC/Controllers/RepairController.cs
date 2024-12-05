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
using Car.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult Create()
        {
            
            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreateRepairCommand command)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }
            await _mediator.Send(command);
            return RedirectToAction(nameof(Create)); //todo
        }

        [HttpPost]
        [Authorize]
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

        [Authorize]
        [Route("Repair/{id}/Edit")]
        public async Task<IActionResult> Edit(int id)
        {
            
            var dto = await _mediator.Send(new GetRepairByIdQuery(id));

            if (!dto.IsEditable)
            {
                return RedirectToAction("NoAccess", "Home");
            }

            if (!dto.IsVisible)
            {
                return RedirectToAction("NoAccess", "Home");
            }

            EditRepairCommand model = _mapper.Map<EditRepairCommand>(dto);

            return View(model);
        }


    }
}
