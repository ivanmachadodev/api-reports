using API.Application.DTOs;
using MediatR;

namespace API.Application.Commands
{
    public record CreateAreaCommand(string Name) : IRequest<AreaDTO>;
}