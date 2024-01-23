using API.Domain.Entities;
using API.Infrastructure.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Infrastructure.Repositories
{
    public class MonedaRepository : IMonedaRepository
    {
        private readonly ReportsEngineContext _context;

        public MonedaRepository(ReportsEngineContext context)
        {
            _context = context;
        }

        public Task DeleteMonedaAsync(int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Moneda> GetMonedasMockUp()
        {
            return new List<Moneda>() { new Moneda()
            {
               id = 100000,
               abreviatura = "ARS",
               descripcion = "Peso Argentino",
               Habilitado = true
            }}.ToList();
        }

        public async Task<IEnumerable<Moneda>> GetAllMonedasAsync()
        {
            var Monedas = await Task.FromResult(GetMonedasMockUp());
            return Monedas;
        }

        public Task<Moneda?> GetMonedaByIdAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public Task SaveMonedaAsync(Moneda moneda, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task UpdateMonedaAsync(Moneda moneda, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
