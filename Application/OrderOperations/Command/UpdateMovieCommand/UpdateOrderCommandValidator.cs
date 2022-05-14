using FluentValidation;

namespace MovieStoreWebApi.Application.OrderOperation.Command.UpdateOrderCommand
{
    public class UpdateOrderCommandValidator:AbstractValidator<UpdateOrderCommand>
    {
        public UpdateOrderCommandValidator()
        {
            RuleFor(x=>x.Id).NotNull().NotEmpty().GreaterThan(0);
            RuleFor(x=>x.updatedData.MovieId).NotEmpty().NotNull().GreaterThanOrEqualTo(0);
            RuleFor(x=>x.updatedData.CustomerId).NotEmpty().NotNull().GreaterThanOrEqualTo(0);
            RuleFor(x=>x.updatedData.TotalPrice).NotNull().NotEmpty().GreaterThanOrEqualTo(0);
        }
    }
}