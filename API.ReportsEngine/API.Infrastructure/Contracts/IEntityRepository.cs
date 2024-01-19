using API.Domain.Entities;

namespace API.Infrastructure.Contracts
{
    public interface IEntityRepository
    {
        Task<Entity?> GetEntityByIdAsync(int? id);

        Task<IEnumerable<Entity>> GetAllEntitiesAsync();

        Task SaveEntityAsync(Entity entity, CancellationToken cancellationToken);

        Task UpdateEntityAsync(Entity entity, CancellationToken cancellationToken);

        Task DeleteEntityAsync(int id, CancellationToken cancellationToken);
    }
}
