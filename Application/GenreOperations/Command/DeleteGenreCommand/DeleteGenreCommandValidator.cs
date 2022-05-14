using FluentValidation;

namespace MovieStoreWebApi.Application.GenreOperation.Command.DeleteGenreCommand
{
    public class DeleteGenreCommandValidator:AbstractValidator<DeleteGenreCommand>
    {
        public DeleteGenreCommandValidator()
        {
            RuleFor(x=>x.Id);
        }
    }
}