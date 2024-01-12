namespace API.Application.Handlers
{
    //public class UpdateAreaHandler : IRequestHandler<UpdateAreaCommand, AreaDTO>
    //{
    //    private readonly IPersonRepository _personRepository;

    //    public UpdateAreaHandler(IPersonRepository personRepository)
    //    {
    //        _personRepository = personRepository;
    //    }

    //    public async Task<PersonDTO> Handle(UpdateAreaCommand request, CancellationToken cancellationToken)
    //    {
    //        var person = await _personRepository.GetPersonByIdAsync(request.Id/*, cancellationToken*/);

    //        if (person == null)
    //        {
    //            // Opcional: Manejar el caso de no encontrar la persona
    //            return null;
    //        }

    //        person.Name = request.Name;
    //        person.LastName = request.LastName;
    //        person.Address = request.address;
    //        person.Age = request.age;

    //        await _personRepository.UpdatePersonAsync(person, cancellationToken);

    //        return new PersonDTO
    //        {
    //            Id = person.Id,
    //            Name = person.Name,
    //            LastName = person.LastName,
    //            Address = person.Address,
    //            Age = person.Age
    //        };
    //    }
    //}
}
