using MediatR;

namespace API.Application.Commands.FieldCommands
{
    public record DeleteFieldCommand(int id) : IRequest;
}
