namespace Ecommerce.Web.Models.ShoppingCartViewModels
{
    using AutoMapper;
    using Ecommerce.Data.EntityModels;
    using Common.Mapping;

    public class CartItemViewModel : IMapFrom<ProductInfo>, IHaveCustomMapping
    {
        //public int CarId { get; set; }
        public string ProductId { get; set; }

        public string Description { get; set; }

        //public int ExtraId { get; set; }

        //public string ExtraName { get; set; }

        public int Quantity { get; set; }

        public double StandardPrice { get; set; }

        public double Discount { get; set; }

        public string Image { get; set; }

        public void ConfigureMapping(Profile mapper)
        {
            mapper
                .CreateMap<ProductInfo, CartItemViewModel>()
                .ForMember(rf => rf.Description, cfg => cfg.MapFrom(rf => rf.Description))
                .ForMember(rf => rf.Image, cfg => cfg.MapFrom(rf => rf.ImageID))
                .ForMember(rf => rf.ProductId, cfg => cfg.MapFrom(rf => rf.Id))
                .ForMember(rf => rf.StandardPrice, cfg => cfg.MapFrom(rf => rf.StandardPrice));
        }
    }
}
