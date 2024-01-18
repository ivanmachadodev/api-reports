﻿using API.Application.DTOs;
using MediatR;

namespace API.Application.Querys
{
    public record GetEntidadQuery(int? id) : IRequest<IEnumerator<EntidadDTO>>;
}
