using API.Application.DTOs;
using MediatR;

namespace API.Application.Queries.CampoQueries
{
    public record GetAllFieldsQuery : IRequest<IEnumerable<FieldDTO>>;
}
