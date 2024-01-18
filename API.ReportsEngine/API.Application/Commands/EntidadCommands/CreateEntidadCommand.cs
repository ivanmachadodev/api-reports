using API.Application.DTOs;
using MediatR;

namespace API.Application.Commands.EntidadCommands
{
    public record CreateEntidadCommand(string nombre, int areaId) : IRequest<EntidadDTO>;
}
