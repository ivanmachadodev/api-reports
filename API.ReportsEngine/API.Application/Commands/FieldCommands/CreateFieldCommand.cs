using API.Application.DTOs;
using MediatR;

namespace API.Application.Commands.CampoCommands
{
    public record CreateFieldCommand(string name, int entityId) : IRequest<FieldDTO>;

}
