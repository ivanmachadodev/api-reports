using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Domain.Entities
{
    public class Moneda
    {
        [Key]
        public int id { get; set; }
        public string descripcion { get; set; }
        public string abreviatura { get; set; }
        public bool Habilitado { get; set; }
    }
}
