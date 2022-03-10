namespace Ecommerce.Services.Models
{
    using AutoMapper;
    using Common.Mapping;
    using Data.EntityModels;
    using System;

    public class CartItemWithDetailsServiceModel : CartItem, IMapFrom<ProductInfo>, IHaveCustomMapping
    {
        public string Id { get; set; }

        public string Description { get; set; }

        public string UnitOfMesure { get; set; }

        public string SerialNumber { get; set; }

        public double StandardPrice { get; set; }

        public string ImageUrl { get; set; }

        public string DepartmentCode { get; set; }

        public string DepartmentDescription { get; set; }

        public string Vendor { get; set; }

        public string Note { get; set; }

        //public string Concatenation { get; set; }

        public void ConfigureMapping(Profile mapper)
        {
            mapper
              .CreateMap<ProductInfo, CartItemWithDetailsServiceModel>()
              .ForMember(rf => rf.Id, cfg => cfg.MapFrom(rf => rf.Id))
              .ForMember(rf => rf.Description, cfg => cfg.MapFrom(rf => rf.Description))
              .ForMember(rf => rf.UnitOfMesure, cfg => cfg.MapFrom(rf => rf.UnitOfMesure))
              .ForMember(rf => rf.SerialNumber, cfg => cfg.MapFrom(rf => rf.SerialNumber))
              .ForMember(rf => rf.StandardPrice, cfg => cfg.MapFrom(rf => rf.StandardPrice))
              .ForMember(rf => rf.ImageUrl, cfg => cfg.MapFrom(rf => rf.ImageID))
              .ForMember(rf => rf.DepartmentCode, cfg => cfg.MapFrom(rf => rf.DepartmentCode))
              .ForMember(rf => rf.DepartmentDescription, cfg => cfg.MapFrom(rf => rf.DepartmentDescription))
              .ForMember(rf => rf.Vendor, cfg => cfg.MapFrom(rf => rf.Vendor))
              .ForMember(rf => rf.Note, cfg => cfg.MapFrom(rf => rf.Note));
              //.ForMember(rf => rf.Concatenation, cfg => cfg.MapFrom(rf => string.Concat(rf.Description,';',rf.StandardPrice,';', rf.DepartmentDescription)));
        }
    }
}
