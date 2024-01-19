using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Domain.Entities
{
    public class Filter
    {
        [Key]
        public int FiltroId { get; set; }
        public int CampoId { get; set; }
        public int CampoPersonalizadoId { get; set; }
        public string TipoFiltro { get; set; }
        public int Valor { get; set; }
    }
}
