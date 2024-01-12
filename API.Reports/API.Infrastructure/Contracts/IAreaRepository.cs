using API.Domain.Entities;

namespace API.Infrastructure.Contracts
{
    public interface IAreaRepository
    {
        Task SavePersonAsync(Area area, CancellationToken cancellationToken);
        Task UpdatePersonAsync(Area area, CancellationToken cancellationToken);
        Task DeletePersonAsync(int id, CancellationToken cancellationToken);
    }
}
