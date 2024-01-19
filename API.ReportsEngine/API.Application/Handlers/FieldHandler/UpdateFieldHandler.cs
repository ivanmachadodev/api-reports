using API.Application.Commands.FieldCommands;
using API.Application.DTOs;
using API.Infrastructure.Contracts;
using MediatR;

namespace API.Application.Handlers.FieldHandler
{
    public class UpdateFieldHandler : IRequestHandler<UpdateFieldCommand, FieldDTO>
    {
        private readonly IFieldRepository _fieldRepository;

        public UpdateFieldHandler(IFieldRepository fieldRepository)
        {
            _fieldRepository = fieldRepository;
        }

        public async Task<FieldDTO> Handle(UpdateFieldCommand request, CancellationToken cancellationToken)
        {
            var field = await _fieldRepository.GetFieldByIdAsync(request.id/*, cancellationToken*/);

            if (field == null)
            {
                return null;
            }

            field.Name = request.name;
            field.EntityId = request.entityId;

            await _fieldRepository.UpdateFieldAsync(field, cancellationToken);

            return new FieldDTO
            {
                FieldId = field.FieldId,
                Name = field.Name,
                EntityId = field.EntityId,
            };
        }
    }
}
