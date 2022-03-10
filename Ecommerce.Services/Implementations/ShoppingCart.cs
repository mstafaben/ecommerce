namespace Ecommerce.Services.Implementations
{
    using System.Collections.Generic;
    using System.Linq;
	using Ecommerce.Services.Models;


    public class ShoppingCart
    {
        private readonly IList<CartItem> items;

        public ShoppingCart()
        {
            this.items = new List<CartItem>();
        }

        public void AddToCart(string recordingId)
        {
            var cartItem = this.GetCartItem(recordingId);
            if (cartItem == null)
            {
                cartItem = new CartItem
                {
                    ProductId = recordingId,
                    Quantity = 1
                };

                this.items.Add(cartItem);
            }
            else
            {
                cartItem.Quantity++;
            }
        }

        public void ClearCartItems()
            => this.items.Clear();

        public IEnumerable<CartItem> GetItems
            => new List<CartItem>(this.items);

        public void DecreaseQuantity(string recordingId)
        {
            var cartItem = this.GetCartItem(recordingId);
            if (cartItem != null && cartItem.Quantity > 0)
            {
                cartItem.Quantity--;

                if (cartItem.Quantity == 0)
                {
                    this.RemoveFromCart(recordingId);
                }
            }
        }

        public void IncreaseQuantity(string recordingId)
        {
            var cartItem = this.GetCartItem(recordingId);
            if (cartItem != null)
            {
                cartItem.Quantity++;
            }
        }

        public void RemoveFromCart(string recordingId)
        {
            var cartItem = this.GetCartItem(recordingId);
            if (cartItem != null)
            {
                this.items.Remove(cartItem);
            }
        }

        private CartItem GetCartItem(string recordingId)
            => this.items.FirstOrDefault(i => i.ProductId == recordingId);
    }
}
