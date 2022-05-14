using FluentValidation;

namespace MovieStoreWebApi.Application.OrderOperation.Queries.GetByIdOrderQuery
{
    public class GetByIdOrderQueryValidator:AbstractValidator<GetByIdOrderQuery>
    {
        public GetByIdOrderQueryValidator()
        {
            RuleFor(x=>x.Id).NotEmpty().NotNull().GreaterThanOrEqualTo(0);
        }
    }
}