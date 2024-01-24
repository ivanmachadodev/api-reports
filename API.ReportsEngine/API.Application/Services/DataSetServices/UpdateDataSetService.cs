using API.Application.Commands.DataSetCommands;
using API.Application.Commands.DetFieldsOfDataSetCommands;
using API.Application.DTOs;
using API.Infrastructure.Contracts;
using MediatR;

namespace API.Application.Services.DataSetServices
{
    public class UpdateDataSetService : IUpdateDataSetService
    {
        public readonly IDataSetRepository _dataSetRepository;
        public readonly IMediator _mediator;

        public UpdateDataSetService(IDataSetRepository dataSetRepository, IMediator mediator)
        {
            _dataSetRepository = dataSetRepository;
            _mediator = mediator;
        }

        public async Task<DataSetDTO> UpdateDataSet(RegisterDataSetCommand request, CancellationToken cancellationToken)
        {
            var dataSet = await _dataSetRepository.GetDataSetByIdAsync(request.dataSetId);

            if (dataSet == null)
            {
                return null;
            }

            dataSet.Code = request.code;
            dataSet.Name = request.name;
            dataSet.Description = request.description;

            var updateDetFieldsOfDataSetQuery = new UpdateDetFieldsOfDataSetCommand(request.detFieldOfDataSet, dataSet.DataSetId);
            var detFieldsOfDataSetsDTO = await _mediator.Send(updateDetFieldsOfDataSetQuery);

            await _dataSetRepository.UpdateDataSetAsync(dataSet, cancellationToken);

            return new DataSetDTO
            {
                DataSetId = dataSet.DataSetId,
                Code = dataSet.Code,
                Name = dataSet.Name,
                Description = dataSet.Description,
                DetFieldsOfDataSets = detFieldsOfDataSetsDTO
            };
        }
    }
}
