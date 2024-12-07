using Car.Application.Car;
using Car.Application.Car.Commands.CreateRepair;
using Car.Domain.Entities;

namespace Car.MVC.Models
{
    public class CreateRepairViewModel
    {
        public int SelectedMechanicId { get; set; }
        public CreateRepairCommand CreateRepairCommand { get; set; } = new CreateRepairCommand();
        public IEnumerable<CarDto>? Cars { get; set; }
        public IEnumerable<UserDto>? Mechanics { get; set; }
    }
}
