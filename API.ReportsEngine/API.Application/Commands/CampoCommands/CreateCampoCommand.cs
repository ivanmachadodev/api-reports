using API.Application.DTOs;
using MediatR;

namespace API.Application.Commands.CampoCommands
{
    public record CreateCampoCommand(string nombre, int entidadId) : IRequest<CampoDTO>;

}
