using API.Application.DTOs;
using API.Application.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Application.Queries
{
    public record GetItemsQuery ([Service] IItemService service, int? id) : IRequest<IEnumerable<ItemDTO>>;
}
