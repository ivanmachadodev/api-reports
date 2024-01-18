using API.Application.DTOs;
using API.Application.Queries.CampoQueries;
using API.Infrastructure.Contracts;
using MediatR;

namespace API.Application.Handlers.FieldHandler
{
    public class GetFieldByIdHandler : IRequest<IEnumerable<EntityDTO>>
    {
        public readonly IFieldRepository _fieldRepository;

        public GetFieldByIdHandler(IFieldRepository fieldRepository)
        {
            _fieldRepository = fieldRepository;
        }

        public async Task<IEnumerable<FieldDTO>> Handle(GetFieldByIdQuery request, CancellationToken cancellationToken)
        {
            var entitiesDTOs = new List<FieldDTO>();
            var entity = await _fieldRepository.GetFieldByIdAsync(request.id);
            entitiesDTOs.Add(new FieldDTO
            {
                FieldId = entity.FieldId,
                Name = entity.Name,
                EntityId = entity.EntityId,
            });

            return entitiesDTOs;
        }
    }
}
