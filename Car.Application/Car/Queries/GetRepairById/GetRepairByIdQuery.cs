using Car.Application.Car;
using MediatR;

public class GetRepairByIdQuery : IRequest<RepairDto>
{
    public int Id { get; set; }
    public GetRepairByIdQuery(int id)
    {
        Id = id;
    }
}