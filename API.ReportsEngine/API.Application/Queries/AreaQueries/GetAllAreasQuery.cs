using API.Application.DTOs;
using MediatR;

namespace API.Application.Queries.AreaQueries
{
    public record GetAllAreasQuery : IRequest<IEnumerable<AreaDTO>>;
}
