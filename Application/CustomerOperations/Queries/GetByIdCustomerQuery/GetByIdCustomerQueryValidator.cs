using FluentValidation;

namespace MovieStoreWebApi.Application.CustomerOperation.Queries.GetByIdCustomerQuery
{
    public class GetByIdCustomerQueryValidator:AbstractValidator<GetByIdCustomerQuery>
    {
        public GetByIdCustomerQueryValidator()
        {
            RuleFor(x=>x.Id).GreaterThan(0).NotNull().NotEmpty();
        }
    }
}