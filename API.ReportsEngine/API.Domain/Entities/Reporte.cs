using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Domain.Entities
{
    public class Reporte
    {
        [Key]
        public int ReporteId { get; set; }
        public int DataSetId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
    }
}
