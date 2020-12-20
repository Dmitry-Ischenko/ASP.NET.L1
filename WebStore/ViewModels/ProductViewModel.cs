using WebStore.Domain.Entityes;

namespace WebStore.ViewModels
{
    public class ProductViewModel: Product
    {
        public Category Category { get; set; }
        public Brand Brand { get; set; }
    }
}
