using API.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Infrastructure
{
    public class MicroserviceExample2Context : DbContext
    {
        public MicroserviceExample2Context(DbContextOptions<MicroserviceExample2Context> options) : base(options) { }
        public DbSet<Item> Items { get; set; }
    }
}
