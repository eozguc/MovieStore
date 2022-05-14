using FluentValidation;

namespace MovieStoreWebApi.Application.GenreOperation.Command.UpdateGenreCommand
{
    public class UpdateGenreCommandValidator:AbstractValidator<UpdateGenreCommand>
    {
        public UpdateGenreCommandValidator()
        {
            RuleFor(x=>x.Id).NotEmpty().NotNull().GreaterThan(0);
            RuleFor(x=>x.updatedData.Name).NotEmpty().NotNull().MinimumLength(3).MaximumLength(20);
        }
    }
}