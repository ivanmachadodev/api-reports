using API.Application.Commands.AreaCommands;
using API.Infrastructure.Contracts;
using MediatR;

namespace API.Application.Handlers.DataSethandler
{
    public class DeleteDataSetHandler : IRequestHandler<DeleteAreaCommand>
    {
        public readonly IDataSetRepository _dataSetRepository;

        public DeleteDataSetHandler(IDataSetRepository dataSetRepository)
        {
            _dataSetRepository = dataSetRepository;
        }

        public async Task<Unit> Handle(DeleteAreaCommand request, CancellationToken cancellationToken)
        {
            await _dataSetRepository.DeleteDataSetAsync(request.Id, cancellationToken);
            return Unit.Value;
        }
    }
}
