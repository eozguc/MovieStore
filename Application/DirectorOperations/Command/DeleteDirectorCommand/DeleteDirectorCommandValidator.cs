using FluentValidation;

namespace MovieStoreWebApi.Application.DirectorOperation.Command.DeleteDirectorCommand
{
    public class DeleteDirectorCommandValidator:AbstractValidator<DeleteDirectorCommand>
    {
        public DeleteDirectorCommandValidator()
        {
            RuleFor(x=>x.Id).NotNull().NotEmpty().GreaterThan(0);
        }
    }
}