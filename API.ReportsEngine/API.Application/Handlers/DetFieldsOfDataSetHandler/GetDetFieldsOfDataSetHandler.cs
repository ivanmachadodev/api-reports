using API.Application.DTOs;
using API.Application.Queries.DetFieldsOfDataSetQueries;
using API.Infrastructure.Contracts;
using MediatR;

namespace API.Application.Handlers.DetFieldsOfDataSetHandler
{
    public class GetDetFieldsOfDataSetHandler : IRequestHandler<GetAllDetFieldsOfDataSetQuery, IEnumerable<DetFieldsOfDataSetDTO>>
    {
        public readonly IDetFieldsOfDataSetRepository _detFieldsOfDataSetRepository;

        public GetDetFieldsOfDataSetHandler(IDetFieldsOfDataSetRepository detFieldsOfDataSetRepository)
        {
            _detFieldsOfDataSetRepository = detFieldsOfDataSetRepository;
        }

        public async Task<IEnumerable<DetFieldsOfDataSetDTO>> Handle(GetAllDetFieldsOfDataSetQuery request, CancellationToken cancellationToken)
        {
            var fieldsOfDataSetDTO = new List<DetFieldsOfDataSetDTO>();
            var fieldsOfDataSet = await _detFieldsOfDataSetRepository.GetAllDetFieldsOfDataSetByIdAsync(request.id);
            foreach (var field in fieldsOfDataSet)
            {
                fieldsOfDataSetDTO.Add(new DetFieldsOfDataSetDTO
                {
                    DetFieldsOfDataSetId = field.DetFieldsOfDataSetId,
                    DataSetId = field.DataSetId,
                    FieldId = field.FieldId,
                    Filter = field.Filter,
                    FilterType = field.FilterType,
                    Order = field.Order,
                });
            }

            return fieldsOfDataSetDTO;
        }
    }
}
