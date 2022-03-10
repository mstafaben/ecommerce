namespace Ecommerce.Services.Implementations
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using AutoMapper.QueryableExtensions;

    using Data;
    using Ecommerce.Web.Data;
    using Services.Models;
    using Ecommerce.Data.EntityModels;

    public class ProductService : IProductService
    {
        private readonly EcommerceDbContext db;

        public ProductService(EcommerceDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<CartItemWithDetailsServiceModel>> CarModelSearch(string search)
        {
            var result = await this.db.ProductsInfo
                         .Where(s => s.Description.ToLower().Contains(search.ToLower()))
                         .ProjectTo<CartItemWithDetailsServiceModel>()
                         .ToListAsync();

            return result;
        }

        public async Task<CartItemWithDetailsServiceModel> Details(string id)
        {
            var result = await this.db.ProductsInfo
                        .Where(p => p.Id == id)
                        .ProjectTo<CartItemWithDetailsServiceModel>()
                        .FirstOrDefaultAsync();

            return result;
        }

        public async Task<IEnumerable<CartItemWithDetailsServiceModel>> GetProductsAsync()
        {
            var result = await this.db.ProductsInfo
                .Where(el => el.DepartmentCode != null && el.StandardPrice > 0)
                .ProjectTo<CartItemWithDetailsServiceModel>()
                .ToListAsync();

            return result;
        }

        public async Task<IEnumerable<CartItemWithDetailsServiceModel>> ProductDepSearch(string id)
        {
            var result = await this.db.ProductsInfo
                        .Where(item => item.DepartmentCode == id)
                        .ProjectTo<CartItemWithDetailsServiceModel>()
                        .ToListAsync();
            return result;
        }
    }
}
