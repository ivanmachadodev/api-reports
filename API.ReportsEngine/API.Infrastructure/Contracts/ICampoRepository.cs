using API.Domain.Entities;

namespace API.Infrastructure.Contracts
{
    public interface ICampoRepository
    {
        Task<Campo?> GetCampoByIdAsync(int? id);

        Task<IEnumerable<Campo>> GetAllCamposAsync();

        Task SaveCampoAsync(Campo campo, CancellationToken cancellationToken);

        Task UpdateCampoAsync(Campo campo, CancellationToken cancellationToken);

        Task DeleteCampoAsync(int id, CancellationToken cancellationToken);
    }
}
