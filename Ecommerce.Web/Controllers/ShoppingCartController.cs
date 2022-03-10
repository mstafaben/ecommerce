namespace Ecommerce.Web.Controllers
{
    using AutoMapper.QueryableExtensions;

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    using Data;
    using Services;
    using Ecommerce.Data.EntityModels;
    using Ecommerce.Web.Models;
    using Web.Infrastructure.Extensions;
    using Ecommerce.Web.Models.ShoppingCartViewModels;

    //[Authorize]
    public class ShoppingCartController : Controller
    {
        private readonly IShoppingCartManager shoppingCartManager;
        private readonly EcommerceDbContext db;
        private readonly UserManager<User> userManager;

        public ShoppingCartController(
            IShoppingCartManager shoppingCartManager,
            EcommerceDbContext db,
            UserManager<User> userManager)
        {
            this.shoppingCartManager = shoppingCartManager;
            this.db = db;
            this.userManager = userManager;
        }

        public IActionResult AddToCart(string productId)
        {
            var product = this.db
                .ProductsInfo
                .Where(rf => rf.Id == productId)
                .FirstOrDefault();

            //if (product.Quantity == 0)
            //{
            //    this.TempData.AddErrorMessage("No Quantity");
            //    return this.RedirectToAction(nameof(HomeController.Index), "Home");
            //}

            var shoppingCartId = this.HttpContext.Session.GetShoppingCartId();
            this.shoppingCartManager.AddToCart(shoppingCartId, productId);

            var itemsWithDetails = this.GetShoppingCartItems();

            return this.RedirectToAction(nameof(Items));
        }

        public IActionResult Items()
        {
            var itemsWithDetails = this.GetShoppingCartItems();

            return View(itemsWithDetails);
        }

        public IActionResult Remove(string recordingId)
        {
            var shoppingCartId = this.HttpContext.Session.GetShoppingCartId();
            this.shoppingCartManager.RemoveFromCart(shoppingCartId, recordingId);

            return this.RedirectToAction(nameof(Items));
        }

        public IActionResult IncreaseQuantity(string recordingId)
        {
            var shoppingCartId = this.HttpContext.Session.GetShoppingCartId();
            this.shoppingCartManager.IncreaseQuantity(shoppingCartId, recordingId);

            return this.RedirectToAction(nameof(Items));
        }

        public IActionResult DescreaseQuantity(string recordingId)
        {
            var shoppingCartId = this.HttpContext.Session.GetShoppingCartId();
            this.shoppingCartManager.DecreaseQuantity(shoppingCartId, recordingId);

            return this.RedirectToAction(nameof(Items));
        }

        //[Authorize]
        [HttpPost]
        public async Task<IActionResult> FinishOrder(decimal orderTotal)
        {
            //var shoppingCartId = this.HttpContext.Session.GetShoppingCartId();

            //if (orderTotal <= 0)
            //{
            //    this.TempData.AddErrorMessage("Is Empty");

            //    this.shoppingCartManager.Clear(shoppingCartId);

            //    return this.RedirectToAction(nameof(Items));
            //}

            //var cartItems = this.GetShoppingCartItems();
            //var order = new Order
            //{
            //    UserId = this.userManager.GetUserId(this.User),
            //    OrderTotal = orderTotal
            //};

            //var orderItems = new List<OrderItem>();
            //foreach (var item in cartItems)
            //{
            //    orderItems.Add(new OrderItem
            //    {
            //        CarId = item.CarId,
            //        CarTitle = item.CarTitle,
            //        ExtraId = item.ExtraId,
            //        ExtraName = item.ExtraName,
            //        Brand = this.db
            //            .Cars
            //            .Where(r => r.Id == item.CarId)
            //            .Select(r => r.Brand.Name)
            //            .FirstOrDefault(),
            //        Quantity = item.Quantity,
            //        Price = item.Price,
            //        Discount = item.Discount
            //    });

            //    update remaining Qty in db
            //   var carFormat = this.db
            //       .CarInfo
            //       .Where(rf => rf.ExtraId == item.ExtraId
            //                 && rf.CarId == item.CarId)
            //       .FirstOrDefault();
            //    carFormat.Quantity -= item.Quantity;
            //    this.db.CarInfo.Update(carFormat);
            //}

            //order.OrderItems = orderItems;

            //if (orderTotal != order.OrderItems
            //                .Sum(i => i.Quantity * i.Price * (1 - (decimal)i.Discount / 100)))
            //{
            //    this.TempData.AddErrorMessage("NotValid");
            //    return this.RedirectToAction(nameof(Items));
            //}

            //await this.db.Orders.AddAsync(order);
            //await this.db.SaveChangesAsync();

            //this.TempData.AddSuccessMessage("Completed");

            //this.shoppingCartManager.Clear(shoppingCartId);

            return this.RedirectToAction(nameof(Items));
        }

        private List<CartItemViewModel> GetShoppingCartItems()
        {
            var shoppingCartId = this.HttpContext.Session.GetShoppingCartId();

            var items = this.shoppingCartManager.GetItems(shoppingCartId);

            var itemList = items.ToList();

            //var itemQuantitiesInStore = this.db
            //    .ProductsInfo
            //    .Where(rf => itemIds.Any(x => x.ProductId == rf.Id))
            //    .ToDictionary(i => $"{i.Id}", i => i.Quantity);

            //var itemQuantities = items.ToDictionary(i => $"{i.ProductId}", i => i.Quantity);

            var itemsWithDetails = this.db
                .ProductsInfo.AsEnumerable()
                .Where(rf => itemList.Any(x => x.ProductId == rf.Id)).AsQueryable()
                .ProjectTo<CartItemViewModel>()
                .ToList();

            itemsWithDetails
                .ForEach(i => i.Quantity = itemList.FirstOrDefault(x => x.ProductId == i.ProductId).Quantity);

            return itemsWithDetails;
        }
    }
}
