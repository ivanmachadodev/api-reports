using API.Application.DTOs;
using API.Application.Queries.EntidadQueries;
using API.Infrastructure.Contracts;
using MediatR;

namespace API.Application.Handlers.EntityHandler
{
    public class GetAllEntitiesHandler : IRequestHandler<GetAllEntityQuery, IEnumerable<EntityDTO>>
    {
        public readonly IEntityRepository _entityRepository;

        public GetAllEntitiesHandler(IEntityRepository entityRepository)
        {
            _entityRepository = entityRepository;
        }

        public async Task<IEnumerable<EntityDTO>> Handle(GetAllEntityQuery request, CancellationToken cancellationToken)
        {
            var entitiesDTOs = new List<EntityDTO>();
            var entities = await _entityRepository.GetAllEntitiesAsync();
            foreach (var entity in entities)
            {
                entitiesDTOs.Add(new EntityDTO
                {
                    EntityId = entity.EntityId,
                    Name = entity.Name,
                    AreaId = entity.AreaId,
                });
            }

            return entitiesDTOs;
        }
    }
}
