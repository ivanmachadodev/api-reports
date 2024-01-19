using API.Application.Commands.DetFieldsOfDataSetCommands;
using API.Infrastructure.Contracts;
using MediatR;

namespace API.Application.Handlers.DetFieldsOfDataSetHandler
{
    public class DeleteDetFieldsOfDataSetHandler : IRequestHandler<DeleteDetFieldsOfDataSetCommand>
    {
        public readonly IDetFieldsOfDataSetRepository _detFieldsOfDataSetRepository;

        public DeleteDetFieldsOfDataSetHandler(IDetFieldsOfDataSetRepository detFieldsOfDataSetRepository)
        {
            _detFieldsOfDataSetRepository = detFieldsOfDataSetRepository;
        }

        public async Task<Unit> Handle(DeleteDetFieldsOfDataSetCommand request, CancellationToken cancellationToken)
        {
            await _detFieldsOfDataSetRepository.DeleteDetFieldsOfDataSetAsync(request.id, cancellationToken);
            return Unit.Value;
        }
    }
}
