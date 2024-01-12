using API.Domain.Entities;
using API.Infrastructure.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Infrastructure.Repositories
{
    public class AreaRepository : IAreaRepository
    {
        private readonly ReportContext _context;
        public AreaRepository(ReportContext context) 
        {
            _context = context;
        }
        public Task DeletePersonAsync(int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SavePersonAsync(Area area, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task UpdatePersonAsync(Area area, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
