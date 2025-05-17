using PetMaster.Domain.Entities;
using PetMaster.Domain.Repositories;

namespace PetMaster.Domain.Services;
public class ProductService(IProductRepository repository)
{
    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        return await repository.GetAllAsync();
    }

    public async Task<Product?> GetByIdAsync(Guid id)
    {
        return await repository.GetByIdAsync(id);
    }

    public async Task<Product> CreateAsync(Product product)
    {
        return await repository.CreateAsync(product);
    }

    public async Task<Product> UpdateAsync(Product product)
    {
        return await repository.UpdateAsync(product);
    }

    public async Task DeleteAsync(Guid id)
    {
        await repository.DeleteAsync(id);
    }
}
