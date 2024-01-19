using API.Domain.Entities;

namespace API.Infrastructure.Contracts
{
    public interface IDetFieldsOfDataSetRepository
    {
        Task<IEnumerable<DetFieldsOfDataSet>> GetAllDetFieldsOfDataSetByIdAsync(int id);
        Task SaveDetFieldsOfDataSetAsync(IEnumerable<DetFieldsOfDataSet> detFieldsOfDataSet, CancellationToken cancellationToken);
        Task UpdateDetFieldsOfDataSetAsync(IEnumerable<DetFieldsOfDataSet> detFieldsOfDataSet, CancellationToken cancellationToken);
        Task DeleteDetFieldsOfDataSetAsync(int id, CancellationToken cancellationToken);
    }
}
