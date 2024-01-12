using API.Application.DTOs;
using MediatR;

namespace API.Application.Commands.Item
{
    public record CreateItemCommand(string Nombre, string Descripcion, int Precio) : IRequest<ItemDTO>;
}