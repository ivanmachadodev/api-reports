using API.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Infrastructure.Contracts
{
    public interface IReportsEngineContext
    {
        DbSet<Area> Areas { get; set; }
        DbSet<Entity> Entities { get; set; }
        DbSet<Field> Fields { get; set; }
        DbSet<DBFieldsBModel> DBFieldsBModel { get; set; }
        DbSet<DataSet> DataSets { get; set; }
        DbSet<DetFieldsOfDataSet> DetFieldsOfDataSet { get; set; }

        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
