using FluentValidation;

namespace MovieStoreWebApi.Application.ActorOperation.Command.AddActorCommand
{
    public class CreateActorCommandValidator:AbstractValidator<CreateActorCommand>
    {       
        public CreateActorCommandValidator()
        {
            RuleFor(x=>x.Model.Name).MinimumLength(4).NotNull();
            RuleFor(x=>x.Model.SurName).MinimumLength(2).NotNull();
        }
    }
}