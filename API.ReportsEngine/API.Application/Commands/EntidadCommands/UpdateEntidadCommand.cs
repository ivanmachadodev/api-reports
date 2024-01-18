using API.Application.DTOs;
using MediatR;

namespace API.Application.Commands.EntidadCommands
{
    public record UpdateEntidadCommand(int id, string nombre, int areaId) : IRequest<EntidadDTO>;
}
