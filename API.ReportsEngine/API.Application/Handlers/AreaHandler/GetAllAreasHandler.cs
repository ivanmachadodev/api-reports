using API.Application.DTOs;
using API.Application.Queries.AreaQueries;
using API.Infrastructure.Contracts;
using MediatR;

namespace API.Application.Handlers.AreaHandlers
{
    public class GetAllAreasHandler : IRequestHandler<GetAllAreasQuery, IEnumerable<AreaDTO>>
    {
        public readonly IAreaRepository _areaRepository;

        public GetAllAreasHandler(IAreaRepository areaRepository)
        {
            _areaRepository = areaRepository;
        }

        public async Task<IEnumerable<AreaDTO>> Handle(GetAllAreasQuery request, CancellationToken cancellationToken)
        {
            var areasDTOs = new List<AreaDTO>();
            var areas = await _areaRepository.GetAllAreasAsync();
            foreach (var area in areas)
            {
                areasDTOs.Add(new AreaDTO
                {
                    AreaId = area.AreaId,
                    Name = area.Name
                });
            }

            return areasDTOs;
        }
    }
}
