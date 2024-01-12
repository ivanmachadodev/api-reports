using API.Domain.Entities;
using API.Infrastructure.Contracts;

namespace API.Infrastructure.Repositories
{
    public class AreaRepository : IAreaRepository
    {
        private readonly ReportContext _context;

        public AreaRepository(ReportContext context)
        {
            _context = context;
        }

        public async Task SaveAreaAsync(Area area, CancellationToken cancellationToken)
        {
            await _context.Areas.AddAsync(area, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateAreaAsync(Area area, CancellationToken cancellationToken)
        {
            _context.Areas.Update(area);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAreaAsync(int id, CancellationToken cancellationToken)
        {
            var area = await _context.Areas.FindAsync(new object[] { id }, cancellationToken);
            if (area != null)
            {
                _context.Areas.Remove(area);
                await _context.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
