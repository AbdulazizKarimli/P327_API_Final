using FluentValidation;
using Pustok.Business.DTOs.UserDtos;

namespace Pustok.Business.Validators.UserValidators;

public class UserPostDtoValidator : AbstractValidator<UserPostDto>
{
    public UserPostDtoValidator()
    {
        RuleFor(u => u.UserName)
            .NotNull()
            .NotEmpty()
            .MinimumLength(3)
            .MaximumLength(30);
        RuleFor(u => u.Email)
            .NotNull()
            .NotEmpty()
            .MaximumLength(256)
            .EmailAddress();
        RuleFor(u => u.Password)
            .NotNull()
            .NotEmpty();
        RuleFor(u => u.PasswordConfirm)
            .NotNull()
            .NotEmpty()
            .Equal(u => u.Password);
    }
}