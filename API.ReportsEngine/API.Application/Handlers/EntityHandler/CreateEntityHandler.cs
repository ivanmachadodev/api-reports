using API.Application.Commands.EntidadCommands;
using API.Application.DTOs;
using API.Domain.Entities;
using API.Infrastructure.Contracts;
using MediatR;

namespace API.Application.Handlers.EntidadHandler
{
    public class CreateFieldHandler : IRequestHandler<CreateEntityCommand, EntityDTO>
    {
        private readonly IEntityRepository _entityRepository;

        public CreateFieldHandler(IEntityRepository entityRepository)
        {
            _entityRepository = entityRepository;
        }

        public async Task<EntityDTO> Handle(CreateEntityCommand request, CancellationToken cancellationToken)
        {
            var entity = new Entity
            {
                Name = request.name,
                AreaId = request.areaId,
            };

            await _entityRepository.SaveEntityAsync(entity, cancellationToken);

            return new EntityDTO
            {
                EntityId = entity.EntityId,
                Name = entity.Name,
                AreaId = entity.AreaId,
            };
        }
    }
}
