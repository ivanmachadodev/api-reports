using API.Application.DTOs;
using API.Domain.Entities.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Application.Querys
{
    public record GetMonedaQuery(int? id) : IRequest<IEnumerable<MonedaDTO>>;
}
