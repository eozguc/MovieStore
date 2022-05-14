using FluentValidation;

namespace MovieStoreWebApi.Application.ActorOperation.Command.UpdateActorCommand
{
    public class UpdateActorCommandValidator:AbstractValidator<UpdateActorCommand>
    {
        public UpdateActorCommandValidator()
        {
            RuleFor(x =>x.Id).GreaterThan(0).NotNull();
            RuleFor(x=>x.updatedData.Name).MinimumLength(4).NotNull();
            RuleFor(x=>x.updatedData.SurName).MinimumLength(2).NotNull();
        }
    }
}