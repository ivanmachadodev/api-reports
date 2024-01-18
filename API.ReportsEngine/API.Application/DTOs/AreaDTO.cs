using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Application.DTOs
{
    public class AreaDTO
    {
        public int AreaId { get; set; }
        public string Nombre { get; set; }
    }

}
