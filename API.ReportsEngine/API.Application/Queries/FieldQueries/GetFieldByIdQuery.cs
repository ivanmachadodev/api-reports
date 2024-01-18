using API.Application.DTOs;
using MediatR;

namespace API.Application.Queries.CampoQueries
{
    public record GetFieldByIdQuery(int? id) : IRequest<IEnumerable<FieldDTO>>;
}
