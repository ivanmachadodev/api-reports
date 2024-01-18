using API.Application.DTOs;
using MediatR;

namespace API.Application.Commands.AreaCommands
{
    public record CreateAreaCommand(string name) : IRequest<AreaDTO>;
}
