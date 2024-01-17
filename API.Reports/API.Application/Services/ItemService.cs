using API.Application.DTOs;
using API.Domain.Entities;
using MediatR;

namespace API.Application.Services
{
    public class ItemService : IItemService, IRequest<IEnumerable<ItemDTO>>
    {
        private readonly IMicroservice2Connection _microservice2Connection;

        public ItemService(IMicroservice2Connection microservice2Connection)
        {
            _microservice2Connection = microservice2Connection;
        }

        public async Task<IEnumerable<ItemDTO>> GetItems(int? id)
        {
            if (id.HasValue)
            {
                var item = await _microservice2Connection.GetItemMicroserviceByID(id.Value);
                return item != null ? new List<ItemDTO> { item } : Enumerable.Empty<ItemDTO>();
            }
            else
            {
                return await _microservice2Connection.GetItemsMicroservice();
            }
        }
    }
}
