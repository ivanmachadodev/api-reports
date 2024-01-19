using API.Application.DTOs;
using MediatR;

namespace API.Application.Queries.EntityQueries
{
    public record GetEntityByIdQuery(int id) : IRequest<IEnumerable<EntityDTO>>;
}
