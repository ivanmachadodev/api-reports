using API.Application.Services;
using API.Domain.Entities;

namespace API.Application.Handlers.Items
{
    public class GetItemsQueryHandler
    {
        private readonly ItemService _itemService;

        public GetItemsQueryHandler(ItemService itemService)
        {
            _itemService = itemService;
        }

        public async Task<IEnumerable<Item>> Handle(int? id)
        {
            return await _itemService.GetItems(id);
        }
    }
}
