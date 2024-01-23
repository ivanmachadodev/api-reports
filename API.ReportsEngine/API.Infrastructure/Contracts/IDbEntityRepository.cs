using API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Infrastructure.Contracts
{
    public interface IDbEntityRepository
    {
        Task<IEnumerable<CampoPersonalizado>> GetAllMonedasAsync();
    }
}
