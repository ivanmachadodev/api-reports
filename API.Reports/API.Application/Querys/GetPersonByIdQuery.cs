﻿using API.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Application.Querys
{
    public record GetPersonByIdQuery (int id) : IRequest<PersonDTO>;

}
