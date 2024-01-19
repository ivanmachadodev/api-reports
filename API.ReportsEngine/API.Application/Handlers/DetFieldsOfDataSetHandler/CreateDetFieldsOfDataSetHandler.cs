using API.Application.Commands.DetFieldsOfDataSetCommands;
using API.Application.DTOs;
using API.Application.Queries.DetFieldsOfDataSetQueries;
using API.Domain.Entities;
using API.Infrastructure.Contracts;
using MediatR;

namespace API.Application.Handlers.DetFieldsOfDataSetHandler
{
    public class CreateDetFieldsOfDataSetHandler : IRequestHandler<CreateDetFieldsOfDataSetCommand, IEnumerable<DetFieldsOfDataSetDTO>>
    {
        public readonly IDetFieldsOfDataSetRepository _detFieldsOfDataSetRepository;
        public readonly IMediator _mediator;

        public CreateDetFieldsOfDataSetHandler(IDetFieldsOfDataSetRepository detFieldsOfDataSetRepository, IMediator mediator)
        {
            _detFieldsOfDataSetRepository = detFieldsOfDataSetRepository;
            _mediator = mediator;
        }

        public async Task<IEnumerable<DetFieldsOfDataSetDTO>> Handle(CreateDetFieldsOfDataSetCommand request, CancellationToken cancellationToken)
        {
            var detFieldsOfDataSet = new List<DetFieldsOfDataSet>();

            foreach (var field in request.fieldsofDataSet)
            {
                detFieldsOfDataSet.Add(new DetFieldsOfDataSet
                {
                    DataSetId = request.dataSetId,
                    FieldId = field.FieldId,
                    FilterType = field.FilterType,
                    Filter = field.Filter,
                    Order = field.Order,
                });
            }

            await _detFieldsOfDataSetRepository.SaveDetFieldsOfDataSetAsync(detFieldsOfDataSet, cancellationToken);

            var query = new GetAllDetFieldsOfDataSetQuery(request.dataSetId);
            var detFieldsOfDataSetDTO = await _mediator.Send(query);
            return detFieldsOfDataSetDTO;

        }
    }
}
