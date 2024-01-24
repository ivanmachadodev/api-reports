using API.Application.Commands.DataSetCommands;
using API.Application.Commands.DetFieldsOfDataSetCommands;
using API.Application.DTOs;
using API.Domain.Entities;
using API.Infrastructure.Contracts;
using MediatR;

namespace API.Application.Services.DataSetServices
{
    public class CreateDataSetService : ICreateDataSetService
    {
        public readonly IDataSetRepository _dataSetRepository;
        public readonly IMediator _mediator;

        public CreateDataSetService(IDataSetRepository dataSetRepository, IMediator mediator)
        {
            _dataSetRepository = dataSetRepository;
            _mediator = mediator;
        }

        public async Task<DataSetDTO> CreateDataSet(RegisterDataSetCommand request, CancellationToken cancellationToken)
        {
            var dataSet = new DataSet
            {
                Code = request.code,
                Name = request.name,
                Description = request.description,
            };
            await _dataSetRepository.SaveDataSetAsync(dataSet, cancellationToken);

            var createDetFieldsofDataSetQuery = new CreateDetFieldsOfDataSetCommand(request.detFieldOfDataSet, dataSet.DataSetId);
            var detFieldsOfDataSet = await _mediator.Send(createDetFieldsofDataSetQuery);

            return new DataSetDTO
            {
                DataSetId = dataSet.DataSetId,
                Code = dataSet.Code,
                Name = dataSet.Name,
                Description = dataSet.Description,
                DetFieldsOfDataSets = detFieldsOfDataSet
            };
        }
    }
}
