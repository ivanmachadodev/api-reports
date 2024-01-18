using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Domain.Entities
{
    public class Entidad
    {
        [Key]
        public int EntidadId { get; set; }
        public string Nombre { get; set; }
        public int AreaId { get; set; }


        public ICollection<Campo> Campos { get; set; }

    }
}
