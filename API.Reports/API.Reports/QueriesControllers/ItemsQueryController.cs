using API.Application.Handlers.Items;
using API.Domain.Entities;
using HotChocolate.Types;

namespace API.Reports.QueriesControllers
{
    [ExtendObjectType("Query")]
    public class ItemsQueryController
    {
        private readonly GetItemsQueryHandler _getItemsQueryHandler;

        public ItemsQueryController(GetItemsQueryHandler getItemsQueryHandler)
        {
            _getItemsQueryHandler = getItemsQueryHandler;
        }

        public async Task<IEnumerable<Item>> GetItems(int? id)
        {
            return await _getItemsQueryHandler.Handle(id);
        }
    }
}
