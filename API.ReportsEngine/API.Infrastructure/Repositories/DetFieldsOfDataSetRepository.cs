using API.Domain.Entities;
using API.Infrastructure.Contracts;
using Microsoft.EntityFrameworkCore;

namespace API.Infrastructure.Repositories
{
    public class DetFieldsOfDataSetRepository : IDetFieldsOfDataSetRepository
    {
        public readonly IReportsEngineContext _context;

        public DetFieldsOfDataSetRepository(IReportsEngineContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DetFieldsOfDataSet>> GetAllDetFieldsOfDataSetByIdAsync(int id)
        {
            IEnumerable<DetFieldsOfDataSet> detFieldsOfDataSet = await _context.DetFieldsOfDataSet.Where(x => x.DataSetId == id).ToListAsync();
            return detFieldsOfDataSet;
        }

        public async Task SaveDetFieldsOfDataSetAsync(IEnumerable<DetFieldsOfDataSet> detFieldsOfDataSet, CancellationToken cancellationToken)
        {
            await _context.DetFieldsOfDataSet.AddRangeAsync(detFieldsOfDataSet, cancellationToken);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateDetFieldsOfDataSetAsync(IEnumerable<DetFieldsOfDataSet> detFieldsOfDataSet, CancellationToken cancellationToken)
        {
            _context.DetFieldsOfDataSet.UpdateRange(detFieldsOfDataSet);
            await _context.SaveChangesAsync(cancellationToken);
        }
        public async Task DeleteDetFieldsOfDataSetAsync(int id, CancellationToken cancellationToken)
        {
            var detFieldsOfDataSet = await _context.DetFieldsOfDataSet.Where(x => x.DataSetId == id).ToListAsync();
            if (detFieldsOfDataSet != null)
            {
                _context.DetFieldsOfDataSet.RemoveRange(detFieldsOfDataSet);
                await _context.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
