using Ecommerce.Web.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;

namespace Ecommerce.Web.Data
{
    public class EcommerceDbContextFactory : IDesignTimeDbContextFactory<EcommerceDbContext>
    {
        public EcommerceDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<EcommerceDbContext>();
            optionsBuilder.UseSqlServer("Server=localhost;Database=StoreSH;Trusted_Connection=True;Integrated Security=true;MultipleActiveResultSets=true");

            return new EcommerceDbContext(optionsBuilder.Options);
        }
    }
}
