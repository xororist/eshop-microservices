namespace Catalog.API.Products.DeleteProduct;

public record DeleteProductCommnand(Guid Id) : ICommand<DeleteProductResult>;
public record DeleteProductResult(bool IsSuccess);
internal class DeleteProductCommandHandler(IDocumentSession session, ILogger<DeleteProductCommandHandler> logger) 
    : ICommandHandler<DeleteProductCommnand, DeleteProductResult> 
{
    public async Task<DeleteProductResult> Handle(DeleteProductCommnand command, CancellationToken cancellationToken)
    {
        logger.LogInformation("DeleteProductCommandHandler.Handle called with {@Command}", command);

        session.Delete<Product>(command.Id);
        await session.SaveChangesAsync(cancellationToken);

        return new DeleteProductResult(true);
    }
}
