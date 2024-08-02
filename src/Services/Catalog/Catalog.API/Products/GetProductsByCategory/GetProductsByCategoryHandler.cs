namespace Catalog.API.Products.GetProductsByCategory;

public record GetProductsByCategoryQuery(string Category) : IQuery<GetProductsByCategoryResult>;

public record GetProductsByCategoryResult(IEnumerable<Product> Products);

internal class GetProductsByCategoryQueryHandler(
    IDocumentSession session,
    ILogger<GetProductsByCategoryQueryHandler> logger)
    : IQueryHandler<GetProductsByCategoryQuery, GetProductsByCategoryResult>
{
    public async Task<GetProductsByCategoryResult> Handle(GetProductsByCategoryQuery query,
        CancellationToken cancellationToken)
    {
        logger.LogInformation("Get product by category {@Query}", query);
        var products = await session.Query<Product>()
            .Where(p => p.Category.Contains(query.Category))
            .OrderBy(p => p.Price)
            .ToListAsync(cancellationToken);

        return new GetProductsByCategoryResult(products);
    }
}