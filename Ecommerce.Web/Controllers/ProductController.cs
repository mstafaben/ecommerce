namespace Ecommerce.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;

    using Infrastructure.Extensions;
    using Ecommerce.Services;

    public class ProductController : Controller
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        public async Task<IActionResult> Details(string id)
        {
            //if (!await this.productService.Exists(id))
            //{
            //    this.TempData.AddErrorMessage("Not found");
            //    return this.RedirectToAction(nameof(HomeController.Index), "Home");
            //}
            var carDetails = await this.productService.Details(id);

            return this.View(carDetails);
        }
    }
}
