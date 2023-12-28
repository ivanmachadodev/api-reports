using API.Application.DTOs;
using MediatR;

namespace API.Application.Commands.Person
{
    public record CreatePersonCommand(string Name, string LastName) : IRequest<PersonDTO>;
}