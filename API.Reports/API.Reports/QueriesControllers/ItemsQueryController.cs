using API.Application.Services;
using API.Domain.Entities;
using HotChocolate.Types;
using HotChocolate;

namespace API.Reports.QueriesControllers
{
    [ExtendObjectType("Query")]
    public class ItemsQueryController
    {
        public async Task<IEnumerable<Item>> GetItems([Service] IMicroservice2Connection microservice2Connection, int? id)
        {
            if (id.HasValue)
            {
                var item = await microservice2Connection.GetItemMicroserviceByID(id);
                return item != null ? new List<Item> { item } : Enumerable.Empty<Item>();
            }
            else
            {
                return await microservice2Connection.GetItemsMicroservice();
            }
        }
    }
}
