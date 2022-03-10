//using Ecommerce.Web.Data;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Design;
//using System;

//namespace Ecommerce.EntityFramework
//{
//    public class EcommerceDbContextFactory : IDesignTimeDbContextFactory<EcommerceDbContext>
//    {
//        public EcommerceDbContext CreateDbContext(string[] args)
//        {
//            var optionsBuilder = new DbContextOptionsBuilder<EcommerceDbContext>();
//            optionsBuilder.UseSqlServer("Data Source=StoreSH");

//            return new EcommerceDbContext(optionsBuilder.Options);
//        }
//    }
//}
