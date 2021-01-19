using System.Collections.Generic;
using WebStore.Domain.Entities.Base.Interfaces;

namespace WebStore.ViewModels
{
    public class CategoriesViewModel : INamedEntity, IOrderedEntity
    {
        public string Name { get; set; }

        public int Id { get; set; }

        public int Order { get; set; }

        public List<CategoriesViewModel> CildCategory { get; set; } = new();

        public CategoriesViewModel ParentCategory { get; set; }
    }
}
