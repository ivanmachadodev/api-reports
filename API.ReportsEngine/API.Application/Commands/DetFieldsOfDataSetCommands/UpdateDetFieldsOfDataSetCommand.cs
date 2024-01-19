using API.Application.DTOs;
using MediatR;

namespace API.Application.Commands.DetFieldsOfDataSetCommands
{
    public record UpdateDetFieldsOfDataSetCommand(IEnumerable<DetFieldsOfDataSetDTO> fieldsOfDataSet, int dataSetId) : IRequest<IEnumerable<DetFieldsOfDataSetDTO>>;
}
