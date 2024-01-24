using API.Application.Commands.FieldCommands;
using API.Application.DTOs;
using API.Domain.Entities;
using API.Infrastructure.Contracts;
using MediatR;

namespace API.Application.Handlers.FieldHandler
{
    public class CreateFieldHandler : IRequestHandler<CreateFieldCommand, FieldDTO>
    {
        public readonly IFieldRepository _fieldRepository;


        public CreateFieldHandler(IFieldRepository fieldRepository)
        {
            _fieldRepository = fieldRepository;
        }

        public async Task<FieldDTO> Handle(CreateFieldCommand request, CancellationToken cancellationToken)
        {
            //var fieldExists = await _fieldRepository.GetFieldExistsAsync(request.entityId, request.name);
            //if (fieldExists != null)
            //{
            //    return new FieldDTO { FieldId = fieldExists.FieldId, Name = fieldExists.Name, EntityId = fieldExists.EntityId };
            //}

            var field = new Field
            {
                Name = request.name,
                EntityId = request.entityId,
            };

            await _fieldRepository.SaveFieldAsync(field, cancellationToken);

            return new FieldDTO
            {
                FieldId = field.FieldId,
                Name = field.Name,
                EntityId = field.EntityId,
            };
        }
    }
}
