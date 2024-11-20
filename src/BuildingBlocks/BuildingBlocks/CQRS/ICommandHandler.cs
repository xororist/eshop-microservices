using MediatR;

namespace BuildingBlocks.CQRS;

public interface ICommandHandler<in TCommnad> 
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

