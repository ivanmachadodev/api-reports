using API.Application.Commands.FieldCommands;
using API.Application.DTOs;
using API.Infrastructure.Contracts;

namespace API.Application.Handlers.EntidadHandler
{
    public class UpdateEntityHandler
    {
        private readonly IEntityRepository _entityRepository;

        public UpdateEntityHandler(IEntityRepository entityRepository)
        {
            _entityRepository = entityRepository;
        }

        public async Task<EntityDTO> Handle(UpdateFieldCommand request, CancellationToken cancellationToken)
        {
            var entity = await _entityRepository.GetEntityByIdAsync(request.id/*, cancellationToken*/);

            if (entity == null)
            {
                return null;
            }

            entity.Name = request.name;
            entity.EntityId = request.entityId;

            await _entityRepository.UpdateEntityAsync(entity, cancellationToken);

            return new EntityDTO
            {
                EntityId = entity.EntityId,
                Name = entity.Name,
                AreaId = entity.AreaId,
            };
        }
    }
}
