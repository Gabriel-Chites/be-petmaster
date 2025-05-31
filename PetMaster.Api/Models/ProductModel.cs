using PetMaster.Domain.Entities;

namespace PetMaster.Api.Models;

public class ProductModel
{
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int QuantityInStock { get; set; }
    public string Supplier { get; set; } = string.Empty;

    public static explicit operator Product(ProductModel product)
        => new(
            product.Name,
            product.Price,
            product.QuantityInStock,
            product.Supplier);
}
