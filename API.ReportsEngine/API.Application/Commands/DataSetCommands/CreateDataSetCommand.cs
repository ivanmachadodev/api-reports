﻿using API.Application.DTOs;
using MediatR;

namespace API.Application.Commands.DataSetCommands
{
    public record CreateDataSetCommand(int dataSetId, string code, string name, string description, ICollection<DetFieldsOfDataSetDTO> detFieldOfDataSet) : IRequest<DataSetDTO>;
}
