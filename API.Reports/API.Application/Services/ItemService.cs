using API.Application.Services;
using API.Domain.Entities;

namespace API.Application
{
    public class ItemService
    {
        private readonly IMicroservice2Connection _microservice2Connection;

        public ItemService(IMicroservice2Connection microservice2Connection)
        {
            _microservice2Connection = microservice2Connection;
        }

        public async Task<IEnumerable<Item>> GetItems(int? id)
        {
            if (id.HasValue)
            {
                var item = await _microservice2Connection.GetItemMicroserviceByID(id.Value);
                return item != null ? new List<Item> { item } : Enumerable.Empty<Item>();
            }
            else
            {
                return await _microservice2Connection.GetItemsMicroservice();
            }
        }
    }
}
