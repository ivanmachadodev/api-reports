using API.Application.DTOs;
using MediatR;

namespace API.Application.Commands.CampoCommands
{
    public record UpdateCampoCommand(int id, string nombre, int entidadId) : IRequest<CampoDTO>;
}
