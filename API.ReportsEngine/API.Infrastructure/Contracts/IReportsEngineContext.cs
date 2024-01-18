using API.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Infrastructure.Contracts
{
    public interface IReportsEngineContext
    {
        DbSet<Area> Areas { get; set; }
        DbSet<Entidad> Entidades { get; set; }
        DbSet<Campo> Campos { get; set; }
        DbSet<CampoDBs> CamposDBs { get; set; }

        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
