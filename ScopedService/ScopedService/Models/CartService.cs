namespace ScopedService.Models
{

    public interface ICartService
    {
        void AddToCart(string produt);
        List<string> GetCart();
    }
    public class CartService : ICartService
    {
        private readonly List<string>? cart = new List<string>();

        public void AddToCart(string product)
        {
            cart.Add(product);

        }

        public List<string> GetCart()
        {
            return cart;
        }

    }
}
