using API.Application.Commands.DataSetCommands;
using API.Infrastructure.Contracts;
using MediatR;

namespace API.Application.Handlers.DataSethandler
{
    public class DeleteDataSetHandler : IRequestHandler<DeleteDataSetCommand>
    {
        public readonly IDataSetRepository _dataSetRepository;

        public DeleteDataSetHandler(IDataSetRepository dataSetRepository)
        {
            _dataSetRepository = dataSetRepository;
        }

        public async Task<Unit> Handle(DeleteDataSetCommand request, CancellationToken cancellationToken)
        {
            await _dataSetRepository.DeleteDataSetAsync(request.id, cancellationToken);
            return Unit.Value;
        }
    }
}
