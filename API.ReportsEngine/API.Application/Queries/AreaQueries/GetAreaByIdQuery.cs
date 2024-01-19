using API.Application.DTOs;
using MediatR;

namespace API.Application.Queries.AreaQueries
{
    public record GetAreaByIdQuery(int id) : IRequest<IEnumerable<AreaDTO>>;
}
