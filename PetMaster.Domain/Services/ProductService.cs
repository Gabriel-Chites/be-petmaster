using PetMaster.Domain.Entities;
using PetMaster.Domain.Repositories;
using PetMaster.Domain.Response;
using PetMaster.Domain.Services.Interfaces;

namespace PetMaster.Domain.Services;
public class ProductService(IProductRepository repository) : IProductService
{
    public async Task<Result> GetAllAsync()
    {
        var products = await repository.GetAllAsync();
        return new Result(true, products);
    }

    public async Task<Result> GetByIdAsync(Guid id)
    {
        var product = await repository.GetByIdAsync(id);
        return new Result(product is not null, product);
    }

    public async Task<Result> CreateAsync(Product product)
    {
        var productCreated = await repository.CreateAsync(product);
        return new Result(productCreated is not null, productCreated);
    }

    public async Task<Result> UpdateAsync(Guid id, Product product)
    {
        var updated = await repository.UpdateAsync(id, product);
        return new Result(updated, updated ? "Produto atualizado" : "Erro ao atualizar o produto");
    }

    public async Task DeleteAsync(Guid id) => await repository.DeleteAsync(id);
}
