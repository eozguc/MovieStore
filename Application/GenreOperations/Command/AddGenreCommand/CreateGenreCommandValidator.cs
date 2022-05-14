using FluentValidation;

namespace MovieStoreWebApi.Application.GenreOperation.Command.AddGenreCommand
{
    public class CreateGenreCommandValidator:AbstractValidator<CreateGenreCommand>
    {
        public CreateGenreCommandValidator()
        {
            RuleFor(x=>x.createGenreModel.Name).NotNull().NotEmpty().MaximumLength(20).MinimumLength(2);
        }
    }
}