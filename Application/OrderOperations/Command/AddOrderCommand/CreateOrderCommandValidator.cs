using FluentValidation;

namespace MovieStoreWebApi.Application.OrderOperation.Command.AddOrderCommand
{
    public class CreateOrderCommandValidator:AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator()
        {
            RuleFor(x=>x.createOrderModel.CustomerId).NotEmpty().NotNull().GreaterThan(0);
            RuleFor(x=>x.createOrderModel.MovieId).NotEmpty().NotNull().GreaterThan(0);
            RuleFor(x=>x.createOrderModel.TotalPrice).NotNull().NotEmpty().GreaterThanOrEqualTo(0);
        }
    }
}