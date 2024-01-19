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
                dataSetsDTOs.Add(new DataSetDTO
                {
                    DataSetId = dataSet.DataSetId,
                    Code = dataSet.Code,
                    Name = dataSet.Name,
                    Description = dataSet.Description
                });
            }

            return dataSetsDTOs;
        }
    }
}
