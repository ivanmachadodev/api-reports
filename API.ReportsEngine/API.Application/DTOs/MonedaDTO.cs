using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Domain.Entities.ViewModels
{
    public class MonedaDTO
    {
        public int id { get; set; }
        public string descripcion { get; set; }
        public string abreviatura { get; set; }
        public bool Habilitado { get; set; }
    }

    public class MonedaResponseDTO
    {
        public MonedaDTO[] result { get; set; }
    }
}
