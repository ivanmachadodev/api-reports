using API.Application.DTOs;
using MediatR;

namespace API.Application.Querys.Items
{
    public record GetAllItemsQuery() : IRequest<IEnumerable<ItemDTO>>;
}