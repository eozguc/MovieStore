using FluentValidation;

namespace MovieStoreWebApi.Application.DirectorOperation.Command.AddDirectorCommand
{
    public class CreateDirectorCommandValidator:AbstractValidator<CreateDirectorCommand>
    {   
        public CreateDirectorCommandValidator()
        {
            RuleFor(x=>x.createDirectorModel.Name).NotEmpty().NotNull().MinimumLength(3).MaximumLength(20);
            RuleFor(x=>x.createDirectorModel.SurName).NotEmpty().NotNull().MinimumLength(2).MaximumLength(20);
        }
        
    }
}