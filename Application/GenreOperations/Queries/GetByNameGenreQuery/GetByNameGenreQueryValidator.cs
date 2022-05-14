using FluentValidation;

namespace MovieStoreWebApi.Application.GenreOperation.Queries.GetByNameGenreQuery
{
    public class GetByNameGenreQueryValidator:AbstractValidator<GetByNameGenreQuery>
    {
        public GetByNameGenreQueryValidator()
        {
            RuleFor(x=>x.Name).NotEmpty().NotNull().MinimumLength(4).MaximumLength(20);
        }   
    }
}