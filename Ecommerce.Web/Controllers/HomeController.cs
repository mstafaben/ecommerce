namespace Ecommerce.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;

    using Ecommerce.Web.Models;
    using Ecommerce.Services;
    using Ecommerce.Data.EntityModels;

    public class HomeController : Controller
    {
        private readonly IProductService productService;

        public HomeController(IProductService productService)
        {
            this.productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            var recordingsData = await this.productService.GetProductsAsync();
            return View(recordingsData);
        }

        public async Task<IActionResult> TypeSearch(string id)
        {
            var productsDep = await this.productService.ProductDepSearch(id);
            return View("Index", productsDep);
        }

        public async Task<IActionResult> ModelSearch(string search)
        {
            var carModel = await this.productService.CarModelSearch(search);
            if (carModel != null)
            {
                return View("Index", carModel);
            }
            else
            {
                return BadRequest("Sorry no results");
            }
        }

        
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult More()
        {
            return View();
        }

        public IActionResult Blog()
        {
            return View();
        }

        public IActionResult Cart()
        {
            return View();
        }
    }
}
