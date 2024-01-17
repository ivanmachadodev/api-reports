using API.Application.DTOs;
using API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Application.Services
{
    public interface IItemService
    {
        Task<IEnumerable<ItemDTO>> GetItems(int? id);
    }
}
