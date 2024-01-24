using API.Application.Commands.DataSetCommands;
using API.Application.DTOs;

namespace API.Application.Services.DataSetServices
{
    public interface IUpdateDataSetService
    {
        Task<DataSetDTO> UpdateDataSet(RegisterDataSetCommand request, CancellationToken cancellationToken);
    }
}
