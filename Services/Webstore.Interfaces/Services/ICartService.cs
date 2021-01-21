using WebStore.Domain.ViewModels;

namespace Webstore.Interfaces.Services
{
    public interface ICartService
    {
        void AddToCart(int id);

        void DecrementFromCart(int id);

        void RemoveFromCart(int id);

        void Clear();

        CartViewModel TransformFromCart();
    }
}
