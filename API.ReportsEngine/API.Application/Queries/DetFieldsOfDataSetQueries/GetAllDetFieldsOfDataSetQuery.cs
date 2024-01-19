using API.Application.DTOs;
using MediatR;

namespace API.Application.Queries.DetFieldsOfDataSetQueries
{
    public record GetAllDetFieldsOfDataSetQuery(int id) : IRequest<IEnumerable<DetFieldsOfDataSetDTO>>;
}
