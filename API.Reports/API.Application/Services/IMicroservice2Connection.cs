﻿using API.Application.DTOs;
using API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Application.Services
{
    public interface IMicroservice2Connection
    {
        Task<ItemDTO> GetItemMicroserviceByID(int? id);
        Task<IEnumerable<ItemDTO>> GetItemsMicroservice();
    }
}
