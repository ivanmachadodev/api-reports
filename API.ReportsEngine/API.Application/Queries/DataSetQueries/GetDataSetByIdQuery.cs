using API.Application.DTOs;
using MediatR;

namespace API.Application.Queries.DataSetQueries
{
    public record GetDataSetByIdQuery(int id) : IRequest<IEnumerable<DataSetDTO>>;
}
