using API.Application.Commands.DetFieldsOfDataSetCommands;
using API.Application.DTOs;
using API.Application.Queries.DetFieldsOfDataSetQueries;
using API.Domain.Entities;
using API.Infrastructure.Contracts;
using MediatR;

namespace API.Application.Handlers.DetFieldsOfDataSetHandler
{
    public class UpdateDetFieldsOfDataSetHandler : IRequestHandler<UpdateDetFieldsOfDataSetCommand, IEnumerable<DetFieldsOfDataSetDTO>>
    {
        public readonly IDetFieldsOfDataSetRepository _detFieldsOfDataSetRepository;
        public readonly IMediator _mediator;

        public UpdateDetFieldsOfDataSetHandler(IDetFieldsOfDataSetRepository detFieldsOfDataSetRepository, IMediator mediator)
        {
            _detFieldsOfDataSetRepository = detFieldsOfDataSetRepository;
            _mediator = mediator;
        }

        public async Task<IEnumerable<DetFieldsOfDataSetDTO>> Handle(UpdateDetFieldsOfDataSetCommand request, CancellationToken cancellationToken)
        {
            var deleteQuery = new DeleteDetFieldsOfDataSetCommand(request.dataSetId);
            await _mediator.Send(deleteQuery);

            var detFieldsOfDataSet = new List<DetFieldsOfDataSet>();

            foreach (var field in request.fieldsOfDataSet)
            {
                detFieldsOfDataSet.Add(new DetFieldsOfDataSet
                {
                    DataSetId = field.DataSetId,
                    FieldId = field.FieldId,
                    FilterType = field.FilterType,
                    Filter = field.Filter,
                    Order = field.Order,
                });
            }

            await _detFieldsOfDataSetRepository.SaveDetFieldsOfDataSetAsync(detFieldsOfDataSet, cancellationToken);

            var query = new GetAllDetFieldsOfDataSetQuery(request.dataSetId);
            return await _mediator.Send(query);

        }
    }
}
