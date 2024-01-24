using API.Domain.Entities;

namespace API.Infrastructure.Contracts
{
    public interface IAreaRepository
    {
        Task<Area?> GetAreaByIdAsync(int? id);
        Task<Area?> GetAreaByNameAsync(string name);
        Task<IEnumerable<Area>> GetAllAreasAsync();
        Task SaveAreaAsync(Area area, CancellationToken cancellationToken);
        Task UpdateAreaAsync(Area area, CancellationToken cancellationToken);
        Task DeleteAreaAsync(int id, CancellationToken cancellationToken);
    }
}
