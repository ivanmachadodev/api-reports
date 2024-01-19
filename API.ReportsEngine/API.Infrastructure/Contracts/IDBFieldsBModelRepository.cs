using API.Domain.Entities;

namespace API.Infrastructure.Contracts
{
    public interface IDBFieldsBModelRepository
    {
        Task<DBFieldsBModel?> GetDBFieldBModelByIdAsync(int? id);
        Task<IEnumerable<DBFieldsBModel>> GetAllDBFieldsBModelsAsync();
        Task SaveDBFieldBModelAsync(DBFieldsBModel fieldDB, CancellationToken cancellationToken);
        Task UpdateDBFieldBModelAsync(DBFieldsBModel fieldDB, CancellationToken cancellationToken);
        Task DeleteDBFieldBModelAsync(int id, CancellationToken cancellationToken);
    }
}
