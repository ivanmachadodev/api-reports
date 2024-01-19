using API.Domain.Entities;
using API.Infrastructure.Contracts;
using Microsoft.EntityFrameworkCore;

namespace API.Infrastructure.Repositories
{
    public class DataSetRepository : IDataSetRepository
    {
        public readonly IReportsEngineContext _context;

        public DataSetRepository(ReportsEngineContext reportEngineContext)
        {
            _context = reportEngineContext;
        }

        public async Task<IEnumerable<DataSet>> GetAllDataSetsAsync()
        {
            return await _context.DataSets.ToListAsync();
        }

        public async Task<DataSet?> GetDataSetByIdAsync(int? id)
        {
            return await _context.DataSets.FirstOrDefaultAsync(p => p.DataSetId == id);
        }

        public async Task SaveDataSetAsync(DataSet dataSet, CancellationToken cancellationToken)
        {
            await _context.DataSets.AddAsync(dataSet, cancellationToken);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateDataSetAsync(DataSet dataSet, CancellationToken cancellationToken)
        {
            _context.DataSets.Update(dataSet);
            await _context.SaveChangesAsync(cancellationToken);

        }
        public async Task DeleteDataSetAsync(int id, CancellationToken cancellationToken)
        {
            var dataSet = await _context.DataSets.FindAsync(new object[] { id }, cancellationToken);
            if (dataSet != null)
            {
                _context.DataSets.Remove(dataSet);
                await _context.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
