using API.Application.DTOs;
using MediatR;

namespace API.Application.Commands.DetFieldsOfDataSetCommands
{
    public record CreateDetFieldsOfDataSetCommand(IEnumerable<DetFieldsOfDataSetDTO> fieldsofDataSet, int dataSetId) : IRequest<IEnumerable<DetFieldsOfDataSetDTO>>;
}
