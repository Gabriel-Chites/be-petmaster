using PetMaster.Domain.Entities;
using PetMaster.Domain.Repositories;
using PetMaster.Domain.Services.Interfaces;

namespace PetMaster.Domain.Services;
public class ProductService(IProductRepository repository) : IProductService
{
    public async Task<IEnumerable<Product>> GetAllAsync() => await repository.GetAllAsync();

    public async Task<Product?> GetByIdAsync(Guid id) => await repository.GetByIdAsync(id);

    public async Task<Product> CreateAsync(Product product) => await repository.CreateAsync(product);

    public async Task<bool> UpdateAsync(Guid id, Product product) => await repository.UpdateAsync(id, product);

    public async Task DeleteAsync(Guid id) => await repository.DeleteAsync(id);
}
