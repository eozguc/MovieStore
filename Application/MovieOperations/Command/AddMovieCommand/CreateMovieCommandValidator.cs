using FluentValidation;

namespace  MovieStoreWebApi.Application.MovieOperation.Command.AddMovieCommand
{
    public class CreateMovieCommandValidator:AbstractValidator<CreateMovieCommand>
    {
        public CreateMovieCommandValidator()
        {
            RuleFor(x=>x.createMovieModel.Name).NotNull().MaximumLength(30).MinimumLength(1);
            RuleFor(x=>x.createMovieModel.Price).NotNull().GreaterThan(0);
            RuleFor(x=>x.createMovieModel.MovieYear).NotNull().GreaterThan(1900);
            RuleFor(x=>x.createMovieModel.GenreId).NotNull().GreaterThan(0);
            RuleFor(x=>x.createMovieModel.DirectorId).NotNull().GreaterThan(0);        
        }
    }
}