using MediatR;

namespace API.Application.Commands.CampoCommands
{
    public record DeleteCampoCommand(int id) : IRequest;
}
