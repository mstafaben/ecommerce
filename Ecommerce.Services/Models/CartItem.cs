namespace Ecommerce.Services.Models
{
    using Ecommerce.Data.EntityModels;
    using Common.Mapping;

    public class CartItem : IMapFrom<ProductInfo>
    {
        public string ProductId { get; set; }

        public int ExtraId { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }
    }
}
