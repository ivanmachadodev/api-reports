using API.Application.Commands.EntidadCommands;
using API.Infrastructure.Contracts;
using MediatR;

namespace API.Application.Handlers.EntidadHandler
{
    public class DeleteEntityHandler
    {
        private readonly IEntityRepository _entityRepository;

        public DeleteEntityHandler(IEntityRepository entityRepository)
        {
            _entityRepository = entityRepository;
        }

        public async Task<Unit> Handle(DeleteEntityCommand request, CancellationToken cancellationToken)
        {
            await _entityRepository.DeleteEntityAsync(request.id, cancellationToken);
            return Unit.Value; // Indica que la operación se completó exitosamente
        }
    }
}
