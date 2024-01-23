using API.Domain.Entities;
using API.Infrastructure.Contracts;
using Microsoft.EntityFrameworkCore;

namespace API.Infrastructure
{
    public class ReportsEngineContext : DbContext, IReportsEngineContext
    {
        public ReportsEngineContext(DbContextOptions<ReportsEngineContext> options) : base(options) { }

        public DbSet<Area> Areas { get; set; }
        public DbSet<Entity> Entities { get; set; }
        public DbSet<Field> Fields { get; set; }
        public DbSet<DBFieldsBModel> DBFieldsBModel { get; set; }
        public DbSet<DataSet> DataSets { get; set; }
        public DbSet<DetFieldsOfDataSet> DetFieldsOfDataSet { get; set; }
        public DbSet<Moneda> FormaTrabajos { get; set; }
    }
}
