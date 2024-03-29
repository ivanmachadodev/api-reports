﻿using API.Application.DTOs;
using API.Application.Queries.AreaQueries;
using HotChocolate;
using HotChocolate.Types;
using MediatR;

namespace API.ReportsEngine.QueriesControllers
{
    [ExtendObjectType("Query")]
    public class AreaQueryController
    {
        public async Task<IEnumerable<AreaDTO>> GetAreas([Service] IMediator mediator, int? id)
        {
            if (id.HasValue)
            {
                var query = new GetAreaByIdQuery(id.Value);
                return await mediator.Send(query);
            }
            else
            {
                var query = new GetAllAreasQuery();
                return await mediator.Send(query);
            }
        }
    }
}
