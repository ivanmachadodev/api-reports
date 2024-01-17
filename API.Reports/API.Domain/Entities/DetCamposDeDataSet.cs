using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Domain.Entities
{
    public class DetCamposDeDataSet
    {
        [Key]
        public int DetCamposDeDataSetId { get; set; }
        public int DataSetId { get; set; }
        public int CampoId { get; set; }
        public string TipoFiltro { get; set; }
        public string Filtro { get; set; }
        public string Orden { get; set; }

    }
}
