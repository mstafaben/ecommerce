namespace Ecommerce.Data.EntityModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class ProductInfo
    {
        public string Id { get; set; }

        public string Description { get; set; }

        public string UnitOfMesure { get; set; }

        public string SerialNumber { get; set; }

        public double StandardPrice { get; set; }

        public string ImageID { get; set; }

        public string DepartmentCode { get; set; }

        public string DepartmentDescription { get; set; }

        public string Vendor { get; set; }

        public string Note { get; set; }

    }
}
