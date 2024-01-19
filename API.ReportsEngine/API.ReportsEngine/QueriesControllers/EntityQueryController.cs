using API.Application.DTOs;
using API.Application.Queries.EntityQueries;
using HotChocolate;
using HotChocolate.Types;
using MediatR;

namespace API.ReportsEngine.QueriesControllers
{
    [ExtendObjectType("Query")]
    public class EntityQueryController
    {
        public async Task<IEnumerable<EntityDTO>> GetEntities([Service] IMediator mediator, int? id)
        {
            if (id.HasValue)
            {
                var query = new GetEntityByIdQuery(id.Value);
                return await mediator.Send(query);
            }
            else
            {
                var query = new GetAllEntityQuery();
                return await mediator.Send(query);
            }
        }
    }
}
