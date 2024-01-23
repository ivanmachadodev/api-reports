using API.Application.DTOs;
using API.Application.Querys;
using API.Domain.Entities.ViewModels;
using API.ReportsEngine.Controllers;
using HotChocolate;
using HotChocolate.Types;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenTracing;
using Oversoft.URUS.Framework.Interfaces;
using Oversoft.URUS.Framework.MVC.Controller;

namespace API.ReportsEngine.QueriesControllers
{
    [ExtendObjectType("Query")]
    public class MonedaQueryController 
    {
        public readonly IMediator _mediator;
        private const string _servicename = "ReportsEngine";

        public MonedaQueryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IEnumerable<MonedaDTO>> GetMonedas([Service] IMediator mediator, int? id)
        {
            var query = new GetMonedaQuery(id == null ? null : id.Value);
            return await mediator.Send(query);
        }
    }
}