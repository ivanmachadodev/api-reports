using MediatR;

namespace API.Application.Commands.Item
{
    public record DeleteItemCommand(int Id) : IRequest;
}
