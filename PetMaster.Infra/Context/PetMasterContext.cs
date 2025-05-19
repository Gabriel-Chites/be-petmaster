using Microsoft.EntityFrameworkCore;
using PetMaster.Domain.Entities;

namespace PetMaster.Infra.Context;
public class PetMasterContext : DbContext
{
    public PetMasterContext(DbContextOptions<PetMasterContext> options) : base(options)
    {
        
    }

    public DbSet<Pet> Pets { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Responsible> Responsibles { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Service> Services { get; set; }
}
