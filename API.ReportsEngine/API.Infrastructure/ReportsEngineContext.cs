using API.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Infrastructure
{
    public class ReportsEngineContext : DbContext
    {
        public ReportsEngineContext(DbContextOptions<ReportsEngineContext> options) : base(options) { }

        public DbSet<Area> Areas { get; set; }
    }
}
