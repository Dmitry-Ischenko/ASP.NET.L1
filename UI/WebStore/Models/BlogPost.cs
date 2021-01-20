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
        /// Дата создания поста
        /// </summary>
        public DateTime DateCreate { get; set; }

        /// <summary>
        /// Дата размещения (с этой даты, пост будет отображатся)
        /// </summary>
        public DateTime DatePublication { get; set; }

        /// <summary>
        /// Дата редактирования поста
        /// </summary>
        public DateTime DateLastEdit { get; set; }

        /// <summary>
        /// Рейтинг поста (лайки/дизы/либо просмотры?)
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
