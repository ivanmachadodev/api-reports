using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using OpenTracing;
using Oversoft.URUS.Framework.Domain;
using Oversoft.URUS.Framework.DTO.Responses.RestClient;
using Oversoft.URUS.Framework.DTO;
using Oversoft.URUS.Framework.Enums;
using Oversoft.URUS.Framework.Interfaces;
using System.Net;
using System.Security.Claims;
using Oversoft.URUS.Framework.Extensions;
using HotChocolate.Resolvers;
using HotChocolate;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using HotChocolate.Types;

namespace API.ReportsEngine.QueriesControllers
{
    [ExtendObjectType("Query")]
    public class BaseEntityQuery 
    {
        
    }
}
