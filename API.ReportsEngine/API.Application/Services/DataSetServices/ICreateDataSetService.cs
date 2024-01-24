using API.Application.Commands.DataSetCommands;
using API.Application.DTOs;

namespace API.Application.Services.DataSetServices
{
    public interface ICreateDataSetService
    {
        Task<DataSetDTO> CreateDataSet(RegisterDataSetCommand request, CancellationToken cancellationToken);
    }
}
