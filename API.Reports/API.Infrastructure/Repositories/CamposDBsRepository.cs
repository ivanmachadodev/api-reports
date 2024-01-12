using API.Domain.Entities;
using API.Infrastructure.Contracts;
using Microsoft.EntityFrameworkCore;

namespace API.Infrastructure.Repositories
{
    public class CamposDBsRepository : ICamposDBsRepository
    {
        private readonly ReportContext _context;

        public CamposDBsRepository(ReportContext context)
        {
            _context = context;
        }

        public async Task<CampoDBs?> GetCamposDBsByIdAsync(int? id)
        {
            return await _context.CamposDBs.FirstOrDefaultAsync(p => p.ID == id);
        }

        public async Task<IEnumerable<CampoDBs>> GetAllCamposDBssAsync()
        {
            return await _context.CamposDBs.ToListAsync();
        }

        public async Task SaveCamposDBsAsync(CampoDBs CamposDBs, CancellationToken cancellationToken)
        {
            await _context.CamposDBs.AddAsync(CamposDBs, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateCamposDBsAsync(CampoDBs CamposDBs, CancellationToken cancellationToken)
        {
            _context.CamposDBs.Update(CamposDBs);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteCamposDBsAsync(int id, CancellationToken cancellationToken)
        {
            var CamposDBs = await _context.CamposDBs.FindAsync(new object[] { id }, cancellationToken);
            if (CamposDBs != null)
            {
                _context.CamposDBs.Remove(CamposDBs);
                await _context.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
