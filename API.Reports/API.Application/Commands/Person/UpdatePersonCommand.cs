using API.Application.DTOs;
using MediatR;

namespace API.Application.Commands
{
    public record UpdatePersonCommand(int Id, string Name, string LastName, string address, int age) : IRequest<PersonDTO>;
}
