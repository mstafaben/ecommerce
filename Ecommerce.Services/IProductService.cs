namespace Ecommerce.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Ecommerce.Data.EntityModels;
    using Models;

    public interface IProductService
    {
        Task<IEnumerable<CartItemWithDetailsServiceModel>> GetProductsAsync();

        Task<IEnumerable<CartItemWithDetailsServiceModel>> ProductDepSearch(string id);

        Task<CartItemWithDetailsServiceModel> Details(string id);

        Task<IEnumerable<CartItemWithDetailsServiceModel>> CarModelSearch(string search);
    }
}
