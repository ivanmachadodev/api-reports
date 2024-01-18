using API.Application.DTOs;
using MediatR;

namespace API.Application.Querys
{
    public record GetAreaByIdQuery(int id) : IRequest<IEnumerable<AreaDTO>>;
}
