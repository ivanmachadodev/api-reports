using System.ComponentModel.DataAnnotations;

namespace API.Domain.Entities
{
    public class Entity
    {
        [Key]
        public int EntityId { get; set; }
        public string Name { get; set; }
        public int AreaId { get; set; }

        public Area Area { get; set; }


        public ICollection<Field> Fields { get; set; }

    }
}
