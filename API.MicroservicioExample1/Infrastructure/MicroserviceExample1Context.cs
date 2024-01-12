using API.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Infrastructure
{
    public class MicroserviceExample1Context : DbContext
    {
        public MicroserviceExample1Context(DbContextOptions<MicroserviceExample1Context> options) : base(options) { }
        public DbSet<Person> Persons { get; set; }
    }
}
