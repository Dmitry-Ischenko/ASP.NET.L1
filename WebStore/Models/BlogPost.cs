using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore.Models
{
    public class BlogPost
    {
        public int Id { get; set; }

        /// <summary>
        /// Дата создания поста (размещения)
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Рейтинг поста (лайки/дизы)
        /// </summary>
        public int Rating { get; set; }
        /// <summary>
        /// Изображение задника блога
        /// </summary>
        public string ImageBackground { get; set; }
        /// <summary>
        /// Изображение для предварительного просмотра
        /// </summary>
        public string PreviewImage { get; set; }
        /// <summary>
        /// Заголовок поста
        /// </summary>
        public string Header { get; set; }

        /// <summary>
        /// Тело поста с Html разметкой
        /// </summary>
        public string BodyHtml { get; set; }
    }
}
