using API.Domain.Entities;
using API.Infrastructure.Contracts;
using Microsoft.EntityFrameworkCore;

namespace API.Infrastructure.Repositories
{
    public class CampoRepository : ICampoRepository
    {
        private readonly ReportsEngineContext _context;

        public CampoRepository(ReportsEngineContext context)
        {
            _context = context;
        }

        public async Task<Campo?> GetCampoByIdAsync(int? id)
        {
            return await _context.Campos.FirstOrDefaultAsync(p => p.CampoId == id);
        }

        public async Task<IEnumerable<Campo>> GetAllCamposAsync()
        {
            return await _context.Campos.ToListAsync();
        }

        public async Task SaveCampoAsync(Campo campo, CancellationToken cancellationToken)
        {
            await _context.Campos.AddAsync(campo, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateCampoAsync(Campo campo, CancellationToken cancellationToken)
        {
            _context.Campos.Update(campo);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteCampoAsync(int id, CancellationToken cancellationToken)
        {
            var area = await _context.Campos.FindAsync(new object[] { id }, cancellationToken);
            if (area != null)
            {
                _context.Campos.Remove(area);
                await _context.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
