namespace Ecommerce.Services.Implementations
{
    using Models;
    using System.Collections.Concurrent;
    using System.Collections.Generic;

    public class ShoppingCartManager : IShoppingCartManager
    {
        private readonly ConcurrentDictionary<string, ShoppingCart> shoppingCarts;  

        public ShoppingCartManager()
        {
            this.shoppingCarts = new ConcurrentDictionary<string, ShoppingCart>();
        }

        public void AddToCart(string cartId, string productId)
            => this.GetShoppingCart(cartId).AddToCart(productId);

        public void Clear(string cartId)
            => this.GetShoppingCart(cartId).ClearCartItems();

        public void DecreaseQuantity(string cartId, string productId)
            => this.GetShoppingCart(cartId).DecreaseQuantity(productId);

        public IEnumerable<CartItem> GetItems(string cartId)
            => new List<CartItem>(this.GetShoppingCart(cartId).GetItems);

        private ShoppingCart GetShoppingCart(string cartId)
            => this.shoppingCarts.GetOrAdd(cartId, new ShoppingCart());

        public void IncreaseQuantity(string cartId, string productId)
            => this.GetShoppingCart(cartId).IncreaseQuantity(productId);

        public void RemoveFromCart(string cartId, string productId)
            => this.GetShoppingCart(cartId).RemoveFromCart(productId);
    }
}
