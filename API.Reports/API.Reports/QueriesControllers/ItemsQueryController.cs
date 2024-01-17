using API.Application.DTOs;
using API.Application.Handlers.Items;
using API.Application.Queries;
using API.Application.Services;
using API.Domain.Entities;
using HotChocolate;
using HotChocolate.Types;
using MediatR;

namespace API.Reports.QueriesControllers
{
    [ExtendObjectType("Query")]
    public class ItemsQueryController
    {
        private readonly IMediator _mediator;

        public ItemsQueryController(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<IEnumerable<ItemDTO>> GetItems([Service] IItemService itemservice, int? id)
        {
            //return await itemService.GetItems(id);
            var query = new GetItemsQuery(itemservice, id);
            var Items = await _mediator.Send(query);
            return (IEnumerable<ItemDTO>)Items;
        }
    }
}
