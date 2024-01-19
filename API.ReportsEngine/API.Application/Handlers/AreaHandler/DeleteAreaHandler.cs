using API.Application.Commands.AreaCommands;
using API.Infrastructure.Contracts;
using MediatR;

namespace API.Application.Handlers.AreaHandlers
{
    public class DeleteAreaHandler : IRequestHandler<DeleteAreaCommand>
    {
        private readonly IAreaRepository _areaRepository;

        public DeleteAreaHandler(IAreaRepository areaRepository)
        {
            _areaRepository = areaRepository;
        }

        public async Task<Unit> Handle(DeleteAreaCommand request, CancellationToken cancellationToken)
        {
            await _areaRepository.DeleteAreaAsync(request.Id, cancellationToken);
            return Unit.Value; // Indica que la operación se completó exitosamente
        }
    }
}
