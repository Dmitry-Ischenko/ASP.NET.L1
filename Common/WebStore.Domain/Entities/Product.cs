using System.ComponentModel.DataAnnotations.Schema;
using WebStore.Domain.Entities.Base;
using WebStore.Domain.Entities.Base.Interfaces;

namespace WebStore.Domain.Entities
{
    [Table("Products")]
    public class Product : NamedEntity, IOrderedEntity
    {
        public int Order { get; set; }

        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; }

        public int? BrandId { get; set; }

        [ForeignKey(nameof(BrandId))]
        public Brand Brand { get; set; }

        public int Discount { get; set; }

        public string ImageUrl { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public string Description { get; set; }
        
    }
}
