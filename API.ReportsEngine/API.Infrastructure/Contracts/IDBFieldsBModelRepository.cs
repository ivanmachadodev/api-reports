using API.Domain.Entities;

namespace API.Infrastructure.Contracts
{
    public interface IDBFieldsBModelRepository
    {
        Task<DBFieldsBModel?> GetCamposDBsByIdAsync(int? id);
        Task<IEnumerable<DBFieldsBModel>> GetAllCamposDBssAsync();
        Task SaveCamposDBsAsync(DBFieldsBModel fieldDB, CancellationToken cancellationToken);
        Task UpdateCamposDBsAsync(DBFieldsBModel fieldDB, CancellationToken cancellationToken);
        Task DeleteCamposDBsAsync(int id, CancellationToken cancellationToken);
    }
}
