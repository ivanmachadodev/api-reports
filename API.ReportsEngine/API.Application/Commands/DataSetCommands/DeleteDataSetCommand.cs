using MediatR;

namespace API.Application.Commands.DataSetCommands
{
    public record DeleteDataSetCommand(int id) : IRequest;
}
