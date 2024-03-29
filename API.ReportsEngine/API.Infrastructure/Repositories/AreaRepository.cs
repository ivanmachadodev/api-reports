﻿using API.Domain.Entities;
using API.Infrastructure.Contracts;
using Microsoft.EntityFrameworkCore;

namespace API.Infrastructure.Repositories
{
    public class AreaRepository : IAreaRepository
    {
        private readonly IReportsEngineContext _context;

        public AreaRepository(IReportsEngineContext context)
        {
            _context = context;
        }

        public async Task<Area?> GetAreaByIdAsync(int? id)
        {
            return await _context.Areas.FirstOrDefaultAsync(p => p.AreaId == id);
        }

        public async Task<IEnumerable<Area>> GetAllAreasAsync()
        {
            return await _context.Areas.ToListAsync();
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
