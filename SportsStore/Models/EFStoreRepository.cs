namespace SportsStore.Models;

public class EFStoreRepository : IStoreRepository
{
    private StoreDbContext context;

    public EFStoreRepository(StoreDbContext context)
    {
        this.context = context;
    }

    public IQueryable<Product> Products => context.Products;
}