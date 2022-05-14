using FluentValidation;

namespace MovieStoreWebApi.Application.CustomerOperations.Command.UpdateCustomerCommand
{
    public class UpdateCustomerCommandValidator:AbstractValidator<UpdateCustomerCommand>
    {
        public UpdateCustomerCommandValidator()
        {
            RuleFor(x=>x.Id).NotEmpty().NotNull().GreaterThan(0);
            RuleFor(x=>x.updatedData.Name).NotEmpty().NotNull().MinimumLength(3).MaximumLength(20);;
            RuleFor(x=>x.updatedData.SurName).NotEmpty().NotNull().MinimumLength(3).MaximumLength(20);;
        }
    }
}