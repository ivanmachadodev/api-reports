using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Domain.Entities
{
    public class DataSet
    {
        [Key]
        public int DataSetId { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
    }
}
