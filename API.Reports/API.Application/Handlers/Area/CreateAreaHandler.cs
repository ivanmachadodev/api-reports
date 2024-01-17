using API.Application.Commands;
using API.Application.DTOs;
using API.Domain.Entities;
using API.Infrastructure.Contracts;

using MediatR;

namespace API.Application.Handlers

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
                Nombre = request.Name
            };

            await _areaRepository.SaveAreaAsync(area, cancellationToken);

            return new AreaDTO
            {
                Id = area.AreaId,
                Name = area.Nombre
            };
        }
    }
}
