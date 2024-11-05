﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Application.Dishess.Commands.CreateDish
{
    public class CreateDishCommandValidator : AbstractValidator<CreateDishesCommand>
    {
        public CreateDishCommandValidator()
        {
            RuleFor(dish => dish.Price)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Price must be a non-negative number.");

            RuleFor(dish => dish.KiloCalories)
                .GreaterThanOrEqualTo(0)
                .WithMessage("KiloCalories must be a non-negative number.");
        }
    }
}
