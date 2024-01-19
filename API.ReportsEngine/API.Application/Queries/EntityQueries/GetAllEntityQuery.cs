using API.Application.DTOs;
using MediatR;

namespace API.Application.Queries.EntityQueries
{
    public record GetAllEntityQuery : IRequest<IEnumerable<EntityDTO>>;
}
