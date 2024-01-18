using API.Domain.Entities;
using API.Infrastructure.Contracts;
using Microsoft.EntityFrameworkCore;

namespace API.Infrastructure.Repositories
{
    public class EntidadRepository : IEntidadRepository
    {
        private readonly IReportsEngineContext _context;

        public EntidadRepository(IReportsEngineContext context)
        {
            _context = context;
        }

        public async Task<Entidad?> GetEntidadByIdAsync(int? id)
        {
            return await _context.Entidades.FirstOrDefaultAsync(p => p.AreaId == id);
        }

        public async Task<IEnumerable<Entidad>> GetAllEntidadsAsync()
        {
            return await _context.Entidades.ToListAsync();
        }

        public async Task SaveEntidadAsync(Entidad entidad, CancellationToken cancellationToken)
        {
            await _context.Entidades.AddAsync(entidad, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateEntidadAsync(Entidad entidad, CancellationToken cancellationToken)
        {
            _context.Entidades.Update(entidad);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteEntidadAsync(int id, CancellationToken cancellationToken)
        {
            var entidad = await _context.Entidades.FindAsync(new object[] { id }, cancellationToken);
            if (entidad != null)
            {
                _context.Entidades.Remove(entidad);
                await _context.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
