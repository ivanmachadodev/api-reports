using API.Application.DTOs;
using MediatR;

namespace API.Application.Queries.FieldQueries
{
    public record GetFieldByIdQuery(int? id) : IRequest<IEnumerable<FieldDTO>>;
}
