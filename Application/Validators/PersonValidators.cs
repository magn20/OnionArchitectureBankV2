using Application.DTOs;
using FluentValidation;

namespace Application.Validators;

public class PostPersonValidator : AbstractValidator<PostPersonDTO>
{
    public PostPersonValidator()
    {
        RuleFor(p => p.fName).NotEmpty();
        RuleFor(p => p.fName).NotNull();

        RuleFor(p => p.lName).NotEmpty();
        RuleFor(p => p.lName).NotNull();
        
        RuleFor(p => p.adr).NotEmpty();
        RuleFor(p => p.adr).NotNull();
    }
}