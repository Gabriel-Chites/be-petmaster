using Microsoft.EntityFrameworkCore;
using PetMaster.Domain.Entities;
using PetMaster.Domain.Enums;

namespace PetMaster.Infra.Context;
public class PetMasterContext : DbContext
{
    public PetMasterContext(DbContextOptions<PetMasterContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasData([
       new User(
            "Victor",
            "(51) 99999-9999",
            "vito@gmail.com",
            null,
            "000.000.000-00",
            "Store 1",
            EUserType.Admin
        )
        {
            Id = new Guid("00000000-0000-0000-0000-000000000001"),
            RegistrationNumber = "0001",
            Password = "pwd",
            FirstAccess = true
        }
   ]);

    modelBuilder.Entity<Service>().HasData([
        new Service(
            "Banho",
            "Serviço de banho para pets"
        )
        {
            Id = new Guid("00000000-0000-0000-0000-000000000002")
        }
    ]);

    modelBuilder.Entity<Product>().HasData([
        new Product(
            "Ração Premium",
            (decimal)100.00,
            99,
            "Royal"
        )
        {
            Id = new Guid("00000000-0000-0000-0000-000000000003")
        }
    ]);

    modelBuilder.Entity<Pet>().HasData([
        new Pet(
            "Aurora",
            "Gato",
            "Cinza",
            1,
            3.0,
            EPort.Small
        )
        {
            Id = new Guid("00000000-0000-0000-0000-000000000004")
        }
    ]);

    modelBuilder.Entity<Responsible>().HasData([
        new Responsible(
            "Vito",
            "(51) 99999-9999",
            "vito@gmail.com",
            "Rua xxxx Bairo xpto"
        )
        {
            Id = new Guid("00000000-0000-0000-0000-000000000006")
        }
    ]);

    base.OnModelCreating(modelBuilder);

        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Pet> Pets { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Responsible> Responsibles { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Service> Services { get; set; }
}
