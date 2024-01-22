using API.Application.DTOs;
using API.Application.Queries.DataSetQueries;
using API.Infrastructure.Contracts;
using MediatR;

namespace API.Application.Handlers.DataSethandler
{
    public class GetAllDataSetsHandler : IRequestHandler<GetAllDataSetsQuery, IEnumerable<DataSetDTO>>
    {
        public readonly IDataSetRepository _dataSetRepository;

        public GetAllDataSetsHandler(IDataSetRepository dataSetRepository)
        {
            _dataSetRepository = dataSetRepository;
        }

        public async Task<IEnumerable<DataSetDTO>> Handle(GetAllDataSetsQuery request, CancellationToken cancellationToken)
        {
            var dataSetsDTOs = new List<DataSetDTO>();
            var dataSets = await _dataSetRepository.GetAllDataSetsAsync();
            foreach (var dataSet in dataSets)
            {
                var detFieldsDTO = new List<DetFieldsOfDataSetDTO>();
                foreach (var field in dataSet.DetFieldsOfDataSets)
                {
                    detFieldsDTO.Add(new DetFieldsOfDataSetDTO
                    {
                        DataSetId = field.DataSetId,
                        DetFieldsOfDataSetId = field.DataSetId,
                        FieldId = field.FieldId,
                        Filter = field.Filter,
                        FilterType = field.FilterType,
                        Order = field.Order,
                    });
                }

                dataSetsDTOs.Add(new DataSetDTO
                {
                    DataSetId = dataSet.DataSetId,
                    Code = dataSet.Code,
                    Name = dataSet.Name,
                    Description = dataSet.Description,
                    DetFieldsOfDataSets = detFieldsDTO
                });
            }

            return dataSetsDTOs;
        }
    }
}
