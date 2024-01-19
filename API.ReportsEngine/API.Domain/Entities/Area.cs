﻿using System.ComponentModel.DataAnnotations;

namespace API.Domain.Entities
{
    public class Area
    {
        [Key]
        public int AreaId { get; set; }
        public string Name { get; set; }

        public ICollection<Entity> Entities { get; set; }
    }
}
