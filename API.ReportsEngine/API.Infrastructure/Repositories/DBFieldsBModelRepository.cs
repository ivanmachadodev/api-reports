using API.Domain.Entities;
using API.Infrastructure.Contracts;
using Microsoft.EntityFrameworkCore;

namespace API.Infrastructure.Repositories
{
    public class DBFieldsBModelRepository : IDBFieldsBModelRepository
    {
        private readonly IReportsEngineContext _context;

        public DBFieldsBModelRepository(IReportsEngineContext context)
        {
            _context = context;
        }

        public async Task<DBFieldsBModel?> GetDBFieldBModelByIdAsync(int? id)
        {
            return await _context.DBFieldsBModel.FirstOrDefaultAsync(p => p.ID == id);
        }

        public async Task<IEnumerable<DBFieldsBModel>> GetAllDBFieldsBModelsAsync()
        {
            return await _context.DBFieldsBModel.ToListAsync();
        }

        public async Task SaveDBFieldBModelAsync(DBFieldsBModel fieldDB, CancellationToken cancellationToken)
        {
            await _context.DBFieldsBModel.AddAsync(fieldDB, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateDBFieldBModelAsync(DBFieldsBModel fieldDB, CancellationToken cancellationToken)
        {
            _context.DBFieldsBModel.Update(fieldDB);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteDBFieldBModelAsync(int id, CancellationToken cancellationToken)
        {
            var fieldDB = await _context.DBFieldsBModel.FindAsync(new object[] { id }, cancellationToken);
            if (fieldDB != null)
            {
                _context.DBFieldsBModel.Remove(fieldDB);
                await _context.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
