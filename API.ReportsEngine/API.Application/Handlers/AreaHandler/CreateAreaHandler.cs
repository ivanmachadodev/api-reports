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
            var areaExists = await _areaRepository.GetAreaByNameAsync(request.name);
            if (areaExists != null)
            {
                return new AreaDTO { AreaId = areaExists.AreaId, Name = areaExists.Name };
            }

            var area = new Area
            {
                Name = request.name
            };

            await _areaRepository.SaveAreaAsync(area, cancellationToken);

            return new AreaDTO
            {
                AreaId = area.AreaId,
                Name = area.Name
            };
        }
    }
}
