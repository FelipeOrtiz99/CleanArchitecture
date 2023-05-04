using FluentValidation;

namespace CleanArchitecture.Application.Features.Streamers.Commands.Create
{
    public class CreateStreamerCommandValidator : AbstractValidator<CreateStreamerCommand>
    {

        public CreateStreamerCommandValidator()
        {

            RuleFor(p => p.Nombre)
                .NotEmpty().WithMessage("El nombre no puede estar en blanco")
                .NotNull().WithMessage("El nombre no puede estar vacio")
                .MaximumLength(50).WithMessage("El nombre no puede exceder los 50 caracteres");

            RuleFor(p => p.Url)
                .NotEmpty().WithMessage("La Url no puede estar en blanco")
                .NotNull().WithMessage("La Url no puede estar vacia");

        }


    }
}
