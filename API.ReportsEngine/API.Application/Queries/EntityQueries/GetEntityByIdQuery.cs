using API.Application.DTOs;
using MediatR;

namespace API.Application.Queries.EntidadQueries
{
    public record GetEntityByIdQuery(int id) : IRequest<IEnumerable<EntityDTO>>;
}
