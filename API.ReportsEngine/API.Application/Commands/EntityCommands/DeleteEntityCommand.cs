using MediatR;

namespace API.Application.Commands.EntityCommands
{
    public record DeleteEntityCommand(int id) : IRequest;
}
