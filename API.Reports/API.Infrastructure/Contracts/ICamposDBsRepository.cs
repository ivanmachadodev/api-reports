using API.Domain.Entities;

namespace API.Infrastructure.Contracts
{
    public interface ICamposDBsRepository
    {
        Task<CampoDBs?> GetCamposDBsByIdAsync(int? id);
        Task<IEnumerable<CampoDBs>> GetAllCamposDBssAsync();
        Task SaveCamposDBsAsync(CampoDBs CamposDBs, CancellationToken cancellationToken);
        Task UpdateCamposDBsAsync(CampoDBs CamposDBs, CancellationToken cancellationToken);
        Task DeleteCamposDBsAsync(int id, CancellationToken cancellationToken);
    }
}
