using ETradeBackend.Application.Features.Categories.Constants;
using ETradeBackend.Domain.Entities;
using FluentValidation;
using Framework.Application.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.Categories.Rules.ValidationRules;

public class CreateCategoryValidator : ValidatorBase<Category>
{
    public CreateCategoryValidator()
    {
        RuleFor(c => c.Name).NotEmpty().NotNull().WithMessage(CategoryMessages.CategoryNameCannotBeNull);
        RuleFor(c => c.Description).NotEmpty().NotNull().WithMessage(CategoryMessages.CategoryDescriptionCannotBeNull);
    }
}
