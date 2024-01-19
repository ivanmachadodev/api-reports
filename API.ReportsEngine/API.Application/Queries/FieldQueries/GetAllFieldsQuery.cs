using API.Application.DTOs;
using MediatR;

namespace API.Application.Queries.FieldQueries
{
    public record GetAllFieldsQuery : IRequest<IEnumerable<FieldDTO>>;
}
