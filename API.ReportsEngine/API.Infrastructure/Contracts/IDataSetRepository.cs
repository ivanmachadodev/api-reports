using API.Domain.Entities;

namespace API.Infrastructure.Contracts
{
    public interface IDataSetRepository
    {
        Task<DataSet?> GetDataSetByIdAsync(int? id);
        Task<IEnumerable<DataSet>> GetAllDataSetsAsync();

        Task SaveDataSetAsync(DataSet dataSet, CancellationToken cancellationToken);
        Task UpdateDataSetAsync(DataSet dataSet, CancellationToken cancellationToken);
        Task DeleteDataSetAsync(int id, CancellationToken cancellationToken);

    }
}
