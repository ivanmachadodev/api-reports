using API.Application.DTOs;
using MediatR;

namespace API.Application.Commands
{
    public record UpdateAreaCommand(int Id, string Name) : IRequest<AreaDTO>;
}
