using FluentValidation;

namespace MovieStoreWebApi.Application.DirectorOperation.Queries.GetByNameDirectorQuery
{
    public class GetByNameDirectorQueryValidator:AbstractValidator<GetByNameDirectorQuery>
    {
        public GetByNameDirectorQueryValidator()
        {
            RuleFor(x=>x.Name).NotEmpty().NotNull().MinimumLength(3).MaximumLength(20);
            RuleFor(x=>x.SurName).NotEmpty().NotNull().MinimumLength(2).MaximumLength(20);
        }
    }
}