using API.Application.DTOs;
using MediatR;

namespace API.Application.Queries.EntidadQueries
{
    public record GetAllEntityQuery : IRequest<IEnumerable<EntityDTO>>;
}
