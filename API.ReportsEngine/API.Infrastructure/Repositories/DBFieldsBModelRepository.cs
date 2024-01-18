using API.Domain.Entities;
using API.Infrastructure.Contracts;
using Microsoft.EntityFrameworkCore;

namespace API.Infrastructure.Repositories
{
    public class CamposDBsRepository : IDBFieldsBModelRepository
    {
        private readonly IReportsEngineContext _context;

        public CamposDBsRepository(IReportsEngineContext context)
        {
            _context = context;
        }

        public async Task<DBFieldsBModel?> GetCamposDBsByIdAsync(int? id)
        {
            return await _context.DBFieldsBModel.FirstOrDefaultAsync(p => p.ID == id);
        }

        public async Task<IEnumerable<DBFieldsBModel>> GetAllCamposDBssAsync()
        {
            return await _context.DBFieldsBModel.ToListAsync();
        }

        public async Task SaveCamposDBsAsync(DBFieldsBModel fieldDB, CancellationToken cancellationToken)
        {
            await _context.DBFieldsBModel.AddAsync(fieldDB, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateCamposDBsAsync(DBFieldsBModel fieldDB, CancellationToken cancellationToken)
        {
            _context.DBFieldsBModel.Update(fieldDB);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteCamposDBsAsync(int id, CancellationToken cancellationToken)
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
