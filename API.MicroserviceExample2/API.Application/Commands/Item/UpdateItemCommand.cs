using API.Application.DTOs;
using MediatR;

namespace API.Application.Commands.Item
{
    public record UpdateItemCommand(int Id, string Nombre, string Descripcion, int Precio) : IRequest<ItemDTO>;
}
