using API.Application.Commands.AreaCommands;
using API.Application.DTOs;
using API.Infrastructure.Contracts;

namespace API.Application.Handlers.AreaHandlers
{
    public class UpdateAreaHandler
    {
        private readonly IAreaRepository _areaRepository;

        public UpdateAreaHandler(IAreaRepository areaRepository)
        {
            _areaRepository = areaRepository;
        }

        public async Task<AreaDTO> Handle(UpdateAreaCommand request, CancellationToken cancellationToken)
        {
            var area = await _areaRepository.GetAreaByIdAsync(request.Id/*, cancellationToken*/);

            if (area == null)
            {
                return null;
            }

            area.Name = request.name;

            await _areaRepository.UpdateAreaAsync(area, cancellationToken);

            return new AreaDTO
            {
                AreaId = area.AreaId,
                Name = area.Name
            };
        }
    }
}
