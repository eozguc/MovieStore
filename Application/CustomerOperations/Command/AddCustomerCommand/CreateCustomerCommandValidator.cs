using FluentValidation;

namespace MovieStoreWebApi.Application.CustomerOperations.Command.AddCustomerCommand
{
    public class CreateCustomerCommandValidator:AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerCommandValidator()
        {
            RuleFor(Create => Create.createCustomerModel.Name).NotEmpty().NotNull().MinimumLength(3).MaximumLength(20);;
            RuleFor(Create => Create.createCustomerModel.SurName).NotEmpty().NotNull().MinimumLength(3).MaximumLength(20);;
        }
    }
}