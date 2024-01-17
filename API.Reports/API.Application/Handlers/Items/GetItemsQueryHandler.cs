using API.Application.DTOs;
using API.Application.Queries;
using API.Application.Services;
using API.Domain.Entities;
using MediatR;

namespace API.Application.Handlers.Items
{
    public class GetItemsQueryHandler : IRequestHandler<GetItemsQuery, IEnumerable<ItemDTO>>
    {
        private readonly ItemService _itemService;

        public GetItemsQueryHandler(ItemService itemService)
        {
            _itemService = itemService;
        }

        public async Task<IEnumerable<ItemDTO>> Handle(GetItemsQuery request, CancellationToken cancellationToken)
        {
            return await _itemService.GetItems(request.id);
        }
    }
}
