using API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Infrastructure.Contracts
{
    public interface IAreaRepository
    {
        Task<Area?> GetAreaByIdAsync(int? id);
        Task<IEnumerable<Area>> GetAllAreasAsync();
        Task SaveAreaAsync(Area area, CancellationToken cancellationToken);
        Task UpdateAreaAsync(Area area, CancellationToken cancellationToken);
        Task DeleteAreaAsync(int id, CancellationToken cancellationToken);
    }
}
