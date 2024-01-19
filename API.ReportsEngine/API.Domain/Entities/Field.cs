using System.ComponentModel.DataAnnotations;

namespace API.Domain.Entities
{
    public class Field
    {
        [Key]
        public int FieldId { get; set; }
        public string Name { get; set; }
        public int EntityId { get; set; }

        public Entity Entity { get; set; }

    }
}
