using API.Application.DTOs;
using MediatR;

namespace API.Application.Commands.EntityCommands
{
    public record CreateEntityCommand(string name, int areaId) : IRequest<EntityDTO>;
}
