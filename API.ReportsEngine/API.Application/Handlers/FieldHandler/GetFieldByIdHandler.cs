using API.Application.DTOs;
using API.Application.Queries.FieldQueries;
using API.Infrastructure.Contracts;
using MediatR;

namespace API.Application.Handlers.FieldHandler
{
    public class GetFieldByIdHandler : IRequestHandler<GetFieldByIdQuery, IEnumerable<FieldDTO>>
    {
        public readonly IFieldRepository _fieldRepository;

        public GetFieldByIdHandler(IFieldRepository fieldRepository)
        {
            _fieldRepository = fieldRepository;
        }

        public async Task<IEnumerable<FieldDTO>> Handle(GetFieldByIdQuery request, CancellationToken cancellationToken)
        {
            var fieldsDTOs = new List<FieldDTO>();
            var field = await _fieldRepository.GetFieldByIdAsync(request.id);
            fieldsDTOs.Add(new FieldDTO
            {
                FieldId = field.FieldId,
                Name = field.Name,
                EntityId = field.EntityId,
            });

            return fieldsDTOs;
        }
    }
}
