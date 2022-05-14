using FluentValidation;

namespace MovieStoreWebApi.Application.ActorOperation.Queries.GetByNameActorQuery
{
    public class GetByNameActorQueryValidator:AbstractValidator<GetByNameActorQuery>
    {
        public GetByNameActorQueryValidator()
        {
            RuleFor(x=>x.Name).MinimumLength(3).NotNull();
            RuleFor(x=>x.SurName).MinimumLength(3).NotNull();
        }
    }
}