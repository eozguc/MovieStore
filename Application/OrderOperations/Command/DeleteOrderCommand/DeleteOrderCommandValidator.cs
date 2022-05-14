using FluentValidation;
namespace MovieStoreWebApi.Application.OrderOperation.Command.DeleteOrderCommand
{
    public class DeleteOrderCommandValidator:AbstractValidator<DeleteOrderCommand>
    {
        public DeleteOrderCommandValidator()
        {
            RuleFor(x=>x.Id).NotEmpty().NotNull().GreaterThan(0);           
        }
    }
}