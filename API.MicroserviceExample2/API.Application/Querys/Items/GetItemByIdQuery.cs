using API.Application.DTOs;
using MediatR;

namespace API.Application.Querys.Items
{
    public record GetItemByIdQuery(int id) : IRequest<ItemDTO>;

}