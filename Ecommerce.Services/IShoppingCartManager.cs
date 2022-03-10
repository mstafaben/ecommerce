namespace Ecommerce.Services
{
    using Models;
    using System.Collections.Generic;

    public interface IShoppingCartManager
    {
        void AddToCart(string cartId, string productId);

        IEnumerable<CartItem> GetItems(string cartId);

        void RemoveFromCart(string cartId, string productId);

        void IncreaseQuantity(string cartId, string productId);

        void DecreaseQuantity(string cartId, string productId);

        void Clear(string cartId);
    }
}
