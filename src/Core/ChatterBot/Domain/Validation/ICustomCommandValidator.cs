﻿using ChatterBot.Core.SimpleCommands;
using FluentValidation;

namespace ChatterBot.Domain.Validation
{
    public interface ICustomCommandValidator : IValidator<CustomCommand>
    {
    }
}
