using PetMaster.Domain.Entities;
using PetMaster.Domain.Repositories;
using PetMaster.Infra.Context;

namespace PetMaster.Infra.Repositories;
public class ProductRepository(PetMasterContext context) 
    : RepositoryBase<Product>(context), IProductRepository
{
}
