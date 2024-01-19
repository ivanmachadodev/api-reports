using API.Application.DTOs;
using MediatR;

namespace API.Application.Commands.EntityCommands
{
    public record UpdateEntityCommand(int id, string name, int areaId) : IRequest<EntityDTO>;
}
