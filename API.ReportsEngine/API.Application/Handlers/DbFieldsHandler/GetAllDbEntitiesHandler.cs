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

namespace API.Application.Handlers.DbFieldsHandler
{
    //public class GetAllDbEntitiesHandler : IRequestHandler<GetDbEntitiesQuery, IEnumerable<DbEntityDTO>>
    //{
    //    public readonly IDbEntityRepository _repository;

    //    public GetAllDbEntitiesHandler(IDbEntityRepository repository)
    //    {
    //        _repository = repository;
    //    }

    //    public async Task<IEnumerable<MonedaDTO>> Handle(GetDbEntitiesQuery request, CancellationToken cancellationToken)
    //    {
    //        var MonedasDTOs = new List<MonedaDTO>();

    //        var servicio = new MonedaService();

    //        var resultado = await servicio.GetAsync();

    //        return resultado;
    //    }

    //    Task<IEnumerable<DbEntityDTO>> IRequestHandler<GetDbEntitiesQuery, IEnumerable<DbEntityDTO>>.Handle(GetDbEntitiesQuery request, CancellationToken cancellationToken)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}
