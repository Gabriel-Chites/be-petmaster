using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using PetMaster.Infra.Context;

namespace PetMaster.Infra.Factory
{
    public class PetMasterContextFactory : IDesignTimeDbContextFactory<PetMasterContext>
    {
        public PetMasterContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<PetMasterContext>();

            optionsBuilder.UseSqlServer("Server=localhost;Database=PetMasterDb;Trusted_Connection=True;TrustServerCertificate=True;");

            return new PetMasterContext(optionsBuilder.Options);
        }
    }
}
