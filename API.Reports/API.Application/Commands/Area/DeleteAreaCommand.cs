using MediatR;

namespace API.Application.Commands
{
    public record DeleteAreaCommand(int Id) : IRequest;
}
