using FluentValidation;

namespace CleanArchitecture.Application.Features.Directors.Commands.CreateDirector
{
    public class CreateCommandValidator : AbstractValidator<CreateDirectorCommand>
    {
        public CreateCommandValidator()
        {
            RuleFor(p => p.Nombre)
                .NotNull().WithMessage("El {Nombre} no puede ser nulo");
            RuleFor(p => p.Apellido)
                .NotNull().WithMessage("El {Apellido} no puede ser nulo");

        }
    }
}
