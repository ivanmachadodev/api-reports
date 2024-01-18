using API.Application.DTOs;
using API.Application.Queries.AreaQueries;
using API.Infrastructure.Contracts;
using MediatR;

namespace API.Application.Handlers.AreaHandlers
{
    public class GetAreaByIdHandler : IRequestHandler<GetAreaByIdQuery, IEnumerable<AreaDTO>>
    {
        public readonly IAreaRepository _areaRepository;

        public GetAreaByIdHandler(IAreaRepository areaRepository)
        {
            _areaRepository = areaRepository;
        }

        public async Task<IEnumerable<AreaDTO>> Handle(GetAreaByIdQuery request, CancellationToken cancellationToken)
        {
            var area = await _areaRepository.GetAreaByIdAsync(request.id);
            var areasDTOs = new List<AreaDTO>
            {
                new AreaDTO
                {
                    AreaId = area.AreaId,
                    Name = area.Name,
                }
            };

            return areasDTOs;
        }
    }
}
