using API.Application.DTOs;
using MediatR;

namespace API.Application.Querys
{
    public record GetCamposQuery(int? id) : IRequest<IEnumerable<CampoDTO>>;
}
