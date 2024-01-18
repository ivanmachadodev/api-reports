using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Domain.Entities
{
    public class Campo
    {
        [Key]
        public int CampoId { get; set; }
        public string Nombre { get; set; }
        public int EntidadId { get; set; }

    }
}
