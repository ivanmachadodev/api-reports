using API.Application.DTOs;
using MediatR;

namespace API.Application.Commands.EntidadCommands
{
    public record CreateEntityCommand(string name, int areaId) : IRequest<EntityDTO>;
}
