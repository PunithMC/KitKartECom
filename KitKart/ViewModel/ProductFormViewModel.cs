using KitKart.Models;

namespace KitKart.ViewModel
{
    public class ProductFormViewModel
    {
        public KartItems kartitems { get; set; }

        public IEnumerable<Category> categories { get; set; }
    }
}
