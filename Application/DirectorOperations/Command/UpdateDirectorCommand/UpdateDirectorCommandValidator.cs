using FluentValidation;

namespace MovieStoreWebApi.Application.DirectorOperation.Command.UpdateDirectorCommand
{
    public class UpdateDirectorCommandValidator:AbstractValidator<UpdateDirectorCommand>
    {
        public UpdateDirectorCommandValidator()
        {
            RuleFor(x=>x.Id).NotEmpty().NotNull().GreaterThan(0);
            RuleFor(x=>x.updatedModel.Name).NotNull().NotEmpty().MinimumLength(3).MaximumLength(20);
            RuleFor(x=>x.updatedModel.SurName).NotNull().NotEmpty().MinimumLength(2).MaximumLength(20);
        }
    }
}