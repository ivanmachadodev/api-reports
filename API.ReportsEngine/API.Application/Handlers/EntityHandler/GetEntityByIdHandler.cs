using API.Application.DTOs;
using API.Application.Queries.EntidadQueries;
using API.Infrastructure.Contracts;
using MediatR;

namespace API.Application.Handlers.EntityHandler
{
    public class GetEntityByIdHandler : IRequest<IEnumerable<EntityDTO>>
    {
        public readonly IEntityRepository _entityRepository;

        public GetEntityByIdHandler(IEntityRepository entityRepository)
        {
            _entityRepository = entityRepository;
        }

        public async Task<IEnumerable<EntityDTO>> Handle(GetEntityByIdQuery request, CancellationToken cancellationToken)
        {
            var entitiesDTOs = new List<EntityDTO>();
            var entity = await _entityRepository.GetEntityByIdAsync(request.id);
            entitiesDTOs.Add(new EntityDTO
            {
                EntityId = entity.EntityId,
                Name = entity.Name,
                AreaId = entity.AreaId,
            });

            return entitiesDTOs;
        }
    }
}
