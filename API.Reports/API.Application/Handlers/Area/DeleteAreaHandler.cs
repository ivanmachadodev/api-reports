using API.Application.Commands;
using API.Infrastructure.Contracts;
using MediatR;

namespace API.Application.Handlers
{
    public class DeleteAreaHandler : IRequestHandler<DeleteAreaCommand>
    {
        private readonly IPersonRepository _personRepository;

        public DeleteAreaHandler(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<Unit> Handle(DeleteAreaCommand request, CancellationToken cancellationToken)
        {
            await _personRepository.DeletePersonAsync(request.Id, cancellationToken);
            return Unit.Value; // Indica que la operación se completó exitosamente
        }
    }
}
