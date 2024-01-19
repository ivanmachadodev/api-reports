using API.Application.DTOs;
using API.Application.Queries.DataSetQueries;
using API.Application.Queries.DetFieldsOfDataSetQueries;
using API.Infrastructure.Contracts;
using MediatR;

namespace API.Application.Handlers.DataSethandler
{
    public class GetDataSetByIdHandler : IRequestHandler<GetDataSetByIdQuery, IEnumerable<DataSetDTO>>
    {
        public readonly IDataSetRepository _dataSetRepository;
        public readonly IMediator _mediator;

        public GetDataSetByIdHandler(IDataSetRepository dataSetRepository, IMediator mediator)
        {
            _dataSetRepository = dataSetRepository;
            _mediator = mediator;
        }

        public async Task<IEnumerable<DataSetDTO>> Handle(GetDataSetByIdQuery request, CancellationToken cancellationToken)
        {
            var dataSet = await _dataSetRepository.GetDataSetByIdAsync(request.id);

            var detFieldsOfDataSetQuery = new GetAllDetFieldsOfDataSetQuery(request.id);
            var detFieldsOfDataSetDTOs = await _mediator.Send(detFieldsOfDataSetQuery);

            if (dataSet == null)
            {
                return Enumerable.Empty<DataSetDTO>();
            }

            var dataSetsDTOs = new List<DataSetDTO>
            {
                new DataSetDTO
                {
                    DataSetId = dataSet.DataSetId,
                    Code = dataSet.Code,
                    Name = dataSet.Name,
                    Description = dataSet.Description,
                    DetFieldsOfDataSets = detFieldsOfDataSetDTOs
                }
            };

            return dataSetsDTOs;
        }
    }
}
