using API.Application.DTOs;
using MediatR;

namespace API.Application.Queries.DataSetQueries
{
    public record GetAllDataSetsQuery : IRequest<IEnumerable<DataSetDTO>>;
}
