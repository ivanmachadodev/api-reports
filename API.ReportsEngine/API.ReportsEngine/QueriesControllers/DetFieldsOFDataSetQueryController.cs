using API.Application.DTOs;
using API.Application.Queries.DetFieldsOfDataSetQueries;
using HotChocolate;
using HotChocolate.Types;
using MediatR;

namespace API.ReportsEngine.QueriesControllers
{
    [ExtendObjectType("Query")]
    public class DetFieldsOFDataSetQueryController
    {
        public async Task<IEnumerable<DetFieldsOfDataSetDTO>> GetDetFieldsOfDataSet([Service] IMediator mediator, int id)
        {
            if (id == null)
            {
                return Enumerable.Empty<DetFieldsOfDataSetDTO>();
            }

            var query = new GetAllDetFieldsOfDataSetQuery(id);
            return await mediator.Send(query);
        }
    }
}
