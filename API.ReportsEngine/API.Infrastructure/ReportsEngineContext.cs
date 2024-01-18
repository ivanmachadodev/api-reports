using API.Domain.Entities;
using API.Infrastructure.Contracts;
using Microsoft.EntityFrameworkCore;

namespace API.Infrastructure
{
    public class ReportsEngineContext : DbContext, IReportsEngineContext
    {
        public ReportsEngineContext(DbContextOptions<ReportsEngineContext> options) : base(options) { }

        public DbSet<Area> Areas { get; set; }
        public DbSet<Entidad> Entidades { get; set; }
        public DbSet<Campo> Campos { get; set; }
        public DbSet<CampoDBs> CamposDBs { get; set; }

    }
}
