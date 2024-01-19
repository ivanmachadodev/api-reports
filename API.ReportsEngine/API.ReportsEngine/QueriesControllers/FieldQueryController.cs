using API.Application.DTOs;
using API.Application.Queries.FieldQueries;
using HotChocolate;
using HotChocolate.Types;
using MediatR;

namespace API.ReportsEngine.QueriesControllers
{
    [ExtendObjectType("Query")]
    public class FieldQueryController
    {
        public async Task<IEnumerable<FieldDTO>> GetFields([Service] IMediator mediator, int? id)
        {
            if (id.HasValue)
            {
                var query = new GetFieldByIdQuery(id.Value);
                return await mediator.Send(query);
            }
            else
            {
                var query = new GetAllFieldsQuery();
                return await mediator.Send(query);
            }
        }
    }
}
