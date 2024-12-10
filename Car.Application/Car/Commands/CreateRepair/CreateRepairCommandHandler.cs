using AutoMapper;
using Car.Application.ApplicationUserFolder;
using Car.Application.Car.Commands.CreateCar;
using Car.Domain.Entities;
using Car.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.Application.Car.Commands.CreateRepair
{
    public class CreateRepairCommandHandler : IRequestHandler<CreateRepairCommand>
    {
        private readonly IMapper _mapper;
        private readonly IRepairRepository _repairRepository;
        private readonly IUserContext _userContext;

        public CreateRepairCommandHandler(IRepairRepository repairRepository, IMapper mapper, IUserContext userContext)
        {
            _mapper = mapper;
            _repairRepository = repairRepository;
            _userContext = userContext;
        }

        public async Task<Unit> Handle(CreateRepairCommand request, CancellationToken cancellationToken)
        {
            
            var repair = _mapper.Map<Domain.Entities.Repair>(request);

            
            if (string.IsNullOrEmpty(repair.Status))
            {
                repair.Status = "Oczekiwanie";
            }
            repair.CreatedById = _userContext.GetCurrentUser().Id;

            
            await _repairRepository.Create(repair);

            return Unit.Value;
        }
    }
}

