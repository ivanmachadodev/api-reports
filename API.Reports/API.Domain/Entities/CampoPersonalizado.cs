using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Domain.Entities
{
    public class CampoPersonalizado
    {
        [Key]
        public int CampoPersonalizadoId { get; set; }
        public string Nombre { get; set; }
        public string OperadorAritmetico { get; set; }
        public string OperadorDeComparacion { get; set; }
        public string OperadorLogico { get; set; }
        public string Separador {  get; set; }
        public string Valor {  get; set; }

    }
}
