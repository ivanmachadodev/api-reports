using MediatR;

namespace API.Application.Commands.CampoCommands
{
    public record DeleteFieldCommand(int id) : IRequest;
}
