using API.Application.DTOs;
using MediatR;

namespace API.Application.Commands.AreaCommands
{
    public record UpdateAreaCommand(int Id, string name) : IRequest<AreaDTO>;
}
