using API.Application.DTOs;
using API.Application.Querys;
using API.Infrastructure.Contracts;
using HotChocolate;
using HotChocolate.Types;
using MediatR;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace API.ReportsEngine.QueriesControllers
{
    [ExtendObjectType("Query")]
    public class AreaQueryController
    {
        public readonly IMediator _mediator;
        public AreaQueryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IEnumerable<AreaDTO>> GetAreas([Service]IMediator mediator, int? id)
        {
            if (id.HasValue)
            {
                var query = new GetAreasQuery(id.Value);
                return await mediator.Send(query);
            }
            else
            {
                var query = new GetAreasQuery(null);
                return await mediator.Send(query);
            }
        }
    }
}
