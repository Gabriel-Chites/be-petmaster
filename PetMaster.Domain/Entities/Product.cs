using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetMaster.Domain.Entities;
public class Product : Entity
{
    public Product(
        string name,
        decimal price,
        int quantityInStock,
        string supplier)
    {
        Name = name;
        Price = price;
        QuantityInStock = quantityInStock;
        Supplier = supplier;
    }

    public string Name { get; set; } = null!;
    public decimal Price { get; set; }
    public int QuantityInStock { get; set; }
    public string Supplier { get; set; } = null!;
}
