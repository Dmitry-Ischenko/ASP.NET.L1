using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore.Domain.ViewModels.Base
{
    public class ViewModel
    {
        /// <summary>
        /// Заголовок окна
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Количество позиций в списке желаний
        /// </summary>
        public int WishlistCount { get; set; }

        /// <summary>
        /// Общая стоимость всех товаров в корзине
        /// </summary>
        public decimal CartSumm { get; set; }

        /// <summary>
        /// Количество товара в корзине
        /// </summary>
        public int CartCount { get; set; }
    }
}
