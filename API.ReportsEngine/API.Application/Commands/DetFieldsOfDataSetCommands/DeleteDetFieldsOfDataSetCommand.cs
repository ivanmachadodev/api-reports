using MediatR;

namespace API.Application.Commands.DetFieldsOfDataSetCommands
{
    public record DeleteDetFieldsOfDataSetCommand(int id) : IRequest;
}
