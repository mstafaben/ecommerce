namespace Ecommerce.Web.Models.HomeViewModels
{
    using Ecommerce.Services.Models;
    using System.Collections.Generic;

    public class HomeIndexViewModel : SearchFormModel
    {
        public IEnumerable<CartItemWithDetailsServiceModel> Cars { get; set; } = new List<CartItemWithDetailsServiceModel>();
    }
}
