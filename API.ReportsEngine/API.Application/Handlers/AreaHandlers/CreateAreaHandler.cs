using API.Application.Commands.AreaCommands;
using API.Application.DTOs;
using API.Domain.Entities;
using API.Infrastructure.Contracts;
using MediatR;

namespace API.Application.Handlers.AreaHandlers
{
    public class CreateAreaHandler : IRequestHandler<CreateAreaCommand, AreaDTO>
    {
        private readonly IAreaRepository _areaRepository;

        public CreateAreaHandler(IAreaRepository areaRepository)
        {
            _areaRepository = areaRepository;
        }

        public async Task<AreaDTO> Handle(CreateAreaCommand request, CancellationToken cancellationToken)
        {
            var area = new Area
            {
                Nombre = request.Nombre
            };

            await _areaRepository.SaveAreaAsync(area, cancellationToken);

            return new AreaDTO
            {
                AreaId = area.AreaId,
                Nombre = area.Nombre
            };
        }
    }
}
