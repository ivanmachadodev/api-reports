using API.Application.DTOs;
using API.Application.Querys;
using API.Application.Services;
using API.Domain.Entities.ViewModels;
using API.Infrastructure.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Application.Handlers.MonedaHandlers
{
    public class GetAllMonedasHandler : IRequestHandler<GetMonedaQuery, IEnumerable<MonedaDTO>>
    {
        public readonly IMonedaRepository _repository;

        public GetAllMonedasHandler(IMonedaRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<MonedaDTO>> Handle(GetMonedaQuery request, CancellationToken cancellationToken)
        {
            var MonedasDTOs = new List<MonedaDTO>();

            var servicio = new MonedaService();

            var resultado = await servicio.GetAsync();

            return resultado;
            //foreach( var item in resultado)
            //{
            //    MonedasDTOs.Add(new MonedaDTO()
            //    {
            //        id = item.id,
            //        Habilitado = item.Habilitado,
            //        descripcion = item.descripcion,
            //        abreviatura = item.abreviatura
            //    });
            //}

            //return MonedasDTOs;
        }
    }
}
