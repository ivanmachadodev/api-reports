using API.Domain.Entities;
using API.Infrastructure.Contracts;
using Microsoft.EntityFrameworkCore;

namespace API.Infrastructure.Repositories
{
    public class FieldRepository : IFieldRepository
    {
        private readonly IReportsEngineContext _context;

        public FieldRepository(IReportsEngineContext context)
        {
            _context = context;
        }

        public async Task<Field?> GetFieldByIdAsync(int? id)
        {
            return await _context.Fields.FirstOrDefaultAsync(p => p.FieldId == id);
        }

        //public async Task<Field?> GetFieldByValueAsync(int? entityId, string name)
        //{
        //    return await _context.Fields.FirstOrDefaultAsync(p => p.EntityId == entityId && p.Name == name);
        //}

        public async Task<IEnumerable<Field>> GetAllFieldsAsync()
        {
            return await _context.Fields.ToListAsync();
        }

        public async Task SaveFieldAsync(Field field, CancellationToken cancellationToken)
        {
            await _context.Fields.AddAsync(field, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateFieldAsync(Field field, CancellationToken cancellationToken)
        {
            _context.Fields.Update(field);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteFieldAsync(int id, CancellationToken cancellationToken)
        {
            var field = await _context.Fields.FindAsync(new object[] { id }, cancellationToken);
            if (field != null)
            {
                _context.Fields.Remove(field);
                await _context.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
