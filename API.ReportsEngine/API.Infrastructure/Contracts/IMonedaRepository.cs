using API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Infrastructure.Contracts
{
    public interface IMonedaRepository
    {
        Task<Moneda?> GetMonedaByIdAsync(int? id);
        Task<IEnumerable<Moneda>> GetAllMonedasAsync();
        Task SaveMonedaAsync(Moneda Moneda, CancellationToken cancellationToken);
        Task UpdateMonedaAsync(Moneda Moneda, CancellationToken cancellationToken);
        Task DeleteMonedaAsync(int id, CancellationToken cancellationToken);
    }
}
