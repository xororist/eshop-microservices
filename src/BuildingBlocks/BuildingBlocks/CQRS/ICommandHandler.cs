using MediatR;

namespace BuildingBlocks.CQRS;

public interface ICommandandler<in TCommnad> 
    : ICommandHandler<TCommnad, Unit>
    where TCommnad : ICommand<Unit>
{
}

public interface ICommandHandler<in TCommand, TReponse>
    : IRequestHandler<TCommand, TReponse> 
    where TCommand : ICommand<TReponse>
    where TReponse : notnull
{
}
