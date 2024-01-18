using API.Application.DTOs;
using API.Application.Querys;
using API.Infrastructure.Contracts;
using MediatR;

namespace API.Application.Handlers.AreaHandlers
{
    public class GetAllAreasHandlers : IRequestHandler<GetAreasQuery, IEnumerable<AreaDTO>>
    {
        public readonly IAreaRepository _areaRepository;

        public GetAllAreasHandlers(IAreaRepository areaRepository)
        {
            _areaRepository = areaRepository;
        }

        public async Task<IEnumerable<AreaDTO>> Handle(GetAreasQuery request, CancellationToken cancellationToken)
        {
            var areasDTOs = new List<AreaDTO>();
            if(request.id.HasValue)
            {
                var area = await _areaRepository.GetAreaByIdAsync(request.id);
                areasDTOs.Add(new AreaDTO
                {
                    AreaId = area.AreaId,
                    Nombre = area.Nombre,
                });
            }
            else
            {
                var areas = await _areaRepository.GetAllAreasAsync();
                foreach (var area in areas)
                {
                    areasDTOs.Add(new AreaDTO
                    {
                        AreaId = area.AreaId,
                        Nombre = area.Nombre
                    });
                }
            }

            return areasDTOs;
            /*
            var areas = await _areaRepository.GetAllAreasAsync();

            

            var areasDTOs = new List<AreaDTO>();
            foreach (var area in areas)
            {
                areasDTOs.Add(new AreaDTO
                {
                    AreaId = area.AreaId,
                    Nombre = area.Nombre
                });
            }

            return areasDTOs;
            */
        }
    }
}
