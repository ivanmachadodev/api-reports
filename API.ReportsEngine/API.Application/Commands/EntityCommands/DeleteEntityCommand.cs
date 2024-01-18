using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Application.Commands.EntidadCommands
{
    public record DeleteEntityCommand(int id) : IRequest;
}
