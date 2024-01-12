using API.Domain.Entities;

namespace API.Infrastructure.Contracts
{
    public interface IAreaRepository
    {
        Task SaveAreaAsync(Area area, CancellationToken cancellationToken);
        Task UpdateAreaAsync(Area area, CancellationToken cancellationToken);
        Task DeleteAreaAsync(int id, CancellationToken cancellationToken);
    }
}
