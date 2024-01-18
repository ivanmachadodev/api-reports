using API.Application.DTOs;
using MediatR;

namespace API.Application.Querys
{
    public record GetAreasQuery(int? id) : IRequest<IEnumerable<AreaDTO>>;
}
