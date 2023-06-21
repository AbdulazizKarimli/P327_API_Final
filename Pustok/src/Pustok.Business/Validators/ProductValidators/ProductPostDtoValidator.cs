using FluentValidation;
using Pustok.Business.DTOs.ProductDtos;

namespace Pustok.Business.Validators.ProductValidators;

public class ProductPostDtoValidator : AbstractValidator<ProductPostDto>
{
    public ProductPostDtoValidator()
    {
        RuleFor(p => p.Name)
            .NotNull()
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(300);
        RuleFor(p => p.Price)
            .NotNull()
            .GreaterThanOrEqualTo(1);
    }
}