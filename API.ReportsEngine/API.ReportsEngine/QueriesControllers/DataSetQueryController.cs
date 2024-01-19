using API.Application.DTOs;
using API.Application.Queries.DataSetQueries;
using HotChocolate;
using HotChocolate.Types;
using MediatR;

namespace API.ReportsEngine.QueriesControllers
{
    [ExtendObjectType("Query")]
    public class DataSetQueryController
    {
        public async Task<IEnumerable<DataSetDTO>> GetDataSet([Service] IMediator mediator, int? id)
        {
            if (id.HasValue)
            {
                var query = new GetDataSetByIdQuery(id.Value);
                return await mediator.Send(query);
            }
            else
            {
                var query = new GetAllDataSetsQuery();
                return await mediator.Send(query);
            }
        }
    }
}
