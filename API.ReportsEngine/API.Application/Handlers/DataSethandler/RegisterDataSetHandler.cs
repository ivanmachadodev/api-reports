using API.Application.Commands.DataSetCommands;
using API.Application.DTOs;
using API.Application.Services.DataSetServices;
using MediatR;

namespace API.Application.Handlers.DataSethandler
{
    public class RegisterDataSetHandler : IRequestHandler<RegisterDataSetCommand, DataSetDTO>
    {
        public readonly ICreateDataSetService _createDataSetService;
        public readonly IUpdateDataSetService _updateDataSetService;

        public RegisterDataSetHandler(ICreateDataSetService createDataSetService, IUpdateDataSetService updateDataSetService)
        {
            _createDataSetService = createDataSetService;
            _updateDataSetService = updateDataSetService;
        }

        public async Task<DataSetDTO> Handle(RegisterDataSetCommand request, CancellationToken cancellationToken)
        {
            var dataSetDTO = new DataSetDTO();

            if (request.dataSetId == 0)
            {
                dataSetDTO = await _createDataSetService.CreateDataSet(request, cancellationToken);
            }
            else
            {
                dataSetDTO = await _updateDataSetService.UpdateDataSet(request, cancellationToken);
            }

            return dataSetDTO;
        }
    }
}
