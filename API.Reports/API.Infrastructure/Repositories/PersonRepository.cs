using API.Domain.Entities;
using API.Infrastructure.Contracts;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Infrastructure.Repositories
{
    public class PersonRepository :IPersonRepository
    {
        public readonly ReportContext _context;
        public PersonRepository(ReportContext context)
        {
            _context = context;
        }
        public Person? GetPersonById(int id)
        {
            return _context.Persons.Find(id);
        }

        public void SavePerson(Person person)
        {
            _context.Persons.Add(person);
            _context.SaveChanges();
        }

        public void EditPerson(Person person)
        {
            _context.Persons.Update(person);
            _context.SaveChanges();
        }

        public void DeletePerson(Person person)
        {
            _context.Persons.Remove(person);
            _context.SaveChanges();
        }
    }
}
