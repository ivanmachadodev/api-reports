using API.Application.Commands.FieldCommands;
using API.Infrastructure.Contracts;
using MediatR;

namespace API.Application.Handlers.FieldHandler
{
    public class DeleteFieldHandler : IRequestHandler<DeleteFieldCommand>
    {
        private readonly IFieldRepository _fieldRepository;

        public DeleteFieldHandler(IFieldRepository fieldRepository)
        {
            _fieldRepository = fieldRepository;
        }

        public async Task<Unit> Handle(DeleteFieldCommand request, CancellationToken cancellationToken)
        {
            await _fieldRepository.DeleteFieldAsync(request.id, cancellationToken);
            return Unit.Value; // Indica que la operación se completó exitosamente
        }
    }
}
