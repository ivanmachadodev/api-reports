﻿using API.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Application.Querys
{
    public record GetDbEntitiesQuery(int id) : IRequest<IEnumerable<EntityDTO>>;
}
