using API.Application.DTOs;
using API.Application.Queries.CampoQueries;
using API.Infrastructure.Contracts;
using MediatR;

namespace API.Application.Handlers.FieldHandler
{
    public class GetAllFieldsHandler : IRequestHandler<GetAllFieldsQuery, IEnumerable<FieldDTO>>
    {
        public readonly IFieldRepository _fieldRepository;


        public GetAllFieldsHandler(IFieldRepository fieldRepository)
        {
            _fieldRepository = fieldRepository;
        }

        public async Task<IEnumerable<FieldDTO>> Handle(GetAllFieldsQuery request, CancellationToken cancellationToken)
        {
            var fieldsDTOs = new List<FieldDTO>();
            var fields = await _fieldRepository.GetAllFieldsAsync();
            foreach (var field in fieldsDTOs)
            {
                fieldsDTOs.Add(new FieldDTO
                {
                    FieldId = field.FieldId,
                    Name = field.Name,
                    EntityId = field.EntityId,
                });
            }

            return fieldsDTOs;
        }
    }
}
