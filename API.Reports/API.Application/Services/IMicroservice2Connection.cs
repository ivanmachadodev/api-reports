using API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Application.Services
{
    public interface IMicroservice2Connection
    {
        Task<Item> GetItemMicroserviceByID(int? id);
        Task<IEnumerable<Item>> GetItemsMicroservice();
    }
}
