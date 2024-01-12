﻿using MediatR;

namespace API.Application.Commands
{
    public record DeletePersonCommand(int Id) : IRequest;
}
