using FluentValidation;

namespace MovieStoreWebApi.Application.ActorOperation.Command.AddMovieToActorCommand
{
    public class AddMovieToActorCommandValidator:AbstractValidator<AddMovieToActorCommand>
    {
        public AddMovieToActorCommandValidator()
        {
            RuleFor(x=>x.newMoviesActorModel.ActorId).NotNull().GreaterThan(0);
            RuleFor(x=>x.newMoviesActorModel.MovieId).NotNull().GreaterThan(0);
        }
    }
}