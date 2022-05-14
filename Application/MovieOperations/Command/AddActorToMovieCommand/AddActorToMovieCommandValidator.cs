using FluentValidation;

namespace MovieStoreWebApi.Application.MovieOperation.Command.AddActorToMovie
{   
    public class AddActorToMovieCommandValidator:AbstractValidator<AddActorToMovieCommand>
    {
        public AddActorToMovieCommandValidator()
        {
            RuleFor(x=>x.newMoviesActor.ActorId).GreaterThan(0).NotNull().NotEmpty();
            RuleFor(x=>x.newMoviesActor.MovieId).GreaterThan(0).NotNull().NotEmpty();
        }
    }
    
}