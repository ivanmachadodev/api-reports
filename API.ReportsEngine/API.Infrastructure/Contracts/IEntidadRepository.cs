using API.Domain.Entities;

namespace API.Infrastructure.Contracts
{
    public interface IEntidadRepository
    {
        Task<Entidad?> GetEntidadByIdAsync(int? id);

        Task<IEnumerable<Entidad>> GetAllEntidadsAsync();

        Task SaveEntidadAsync(Entidad entidad, CancellationToken cancellationToken);

        Task UpdateEntidadAsync(Entidad entidad, CancellationToken cancellationToken);

        Task DeleteEntidadAsync(int id, CancellationToken cancellationToken);
    }
}
