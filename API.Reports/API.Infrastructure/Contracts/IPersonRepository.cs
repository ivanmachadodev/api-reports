using API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Infrastructure.Contracts
{
    public interface IPersonRepository
    {
        Person? GetPersonById(int id);
        void SavePerson(Person person);

        void EditPerson(Person person);

        void DeletePerson(Person person);
    }
}
