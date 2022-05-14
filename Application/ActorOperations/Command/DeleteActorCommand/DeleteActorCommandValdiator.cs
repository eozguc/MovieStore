using FluentValidation;

namespace MovieStoreWebApi.Application.ActorOperation.Command.DeleteActorCommand
{
    public class DeleteActorCommandValdiator:AbstractValidator<DeleteActorCommand>
    {
        public DeleteActorCommandValdiator()
        {
            RuleFor(x=>x.Id).GreaterThan(0).NotNull();
        }
    }
}