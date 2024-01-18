using API.Domain.Entities;
using API.Infrastructure.Contracts;
using Microsoft.EntityFrameworkCore;

namespace API.Infrastructure.Repositories
{
    public class EntityRepository : IEntityRepository
    {
        private readonly IReportsEngineContext _context;

        public EntityRepository(IReportsEngineContext context)
        {
            _context = context;
        }

        public async Task<Entity?> GetEntityByIdAsync(int? id)
        {
            return await _context.Entities.FirstOrDefaultAsync(p => p.AreaId == id);
        }

        public async Task<IEnumerable<Entity>> GetAllEntitiesAsync()
        {
            return await _context.Entities.ToListAsync();
        }

        public async Task SaveEntityAsync(Entity entity, CancellationToken cancellationToken)
        {
            await _context.Entities.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateEntityAsync(Entity entity, CancellationToken cancellationToken)
        {
            _context.Entities.Update(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteEntityAsync(int id, CancellationToken cancellationToken)
        {
            var entity = await _context.Entities.FindAsync(new object[] { id }, cancellationToken);
            if (entity != null)
            {
                _context.Entities.Remove(entity);
                await _context.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
