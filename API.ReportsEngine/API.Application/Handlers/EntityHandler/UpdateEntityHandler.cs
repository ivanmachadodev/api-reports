using API.Application.Commands.EntityCommands;
using API.Application.DTOs;
using API.Infrastructure.Contracts;
using MediatR;

namespace API.Application.Handlers.EntityHandler
{
    public class UpdateEntityHandler : IRequestHandler<UpdateEntityCommand, EntityDTO>
    {
        private readonly IEntityRepository _entityRepository;

        public UpdateEntityHandler(IEntityRepository entityRepository)
        {
            _entityRepository = entityRepository;
        }

        public async Task<EntityDTO> Handle(UpdateEntityCommand request, CancellationToken cancellationToken)
        {
            var entity = await _entityRepository.GetEntityByIdAsync(request.id/*, cancellationToken*/);

            if (entity == null)
            {
                return null;
            }

            entity.Name = request.name;
            entity.AreaId = request.areaId;

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
