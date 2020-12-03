using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Infrastructure.Interfaces;
using WebStore.Models;

namespace WebStore.Infrastructure.Services
{
    public class InMemoryBlogsData: IBlogsData
    {
        private List<BlogPost> _Blogs;

        public InMemoryBlogsData()
        {
            Initialization();
        }
        private void Initialization()
        {
            _Blogs = new();

            _Blogs.Add(new BlogPost
            {
                Date = DateTime.Now,
                Rating = 10,
                Id = 1,
                ImageBackground = "/images/blog_single_background.jpg",
                PreviewImage = "/images/blog_1.jpg",
                Header = "Вася пупкин ограбил магазин Ситилинка",
                BodyHtml = @"<p>Mauris viverra cursus ante laoreet eleifend. Donec vel fringilla ante. Aenean finibus velit id urna vehicula, nec maximus est sollicitudin. Praesent at tempus lectus, eleifend blandit felis. Fusce augue arcu, consequat a nisl aliquet, consectetur elementum turpis. Donec iaculis lobortis nisl, et viverra risus imperdiet eu. Etiam mollis posuere elit non sagittis. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc quis arcu a magna sodales venenatis. Integer non diam sit amet magna luctus mollis ac eu nisi. In accumsan tellus ut dapibus blandit.</p>
<div class=""single_post_quote text - center"">
<div class=""quote_image""><img src=""images / quote.png"" alt=""""></div>
<div class=""quote_text"">Quisque sagittis non ex eget vestibulum. Sed nec ultrices dui. Cras et sagittis erat. Maecenas pulvinar, turpis in dictum tincidunt, dolor nibh lacinia lacus.</div>
<div class=""quote_name"">Liam Neeson</div>
</div>
<p>Praesent ac magna sed massa euismod congue vitae vitae risus. Nulla lorem augue, mollis non est et, eleifend elementum ante. Nunc id pharetra magna.  Praesent vel orci ornare, blandit mi sed, aliquet nisi. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. </p>
"
            });
            _Blogs.Add(new BlogPost
            {
                Date = DateTime.Now,
                Id=2,
                ImageBackground= "/Blog/images/blog2_background.jpg",
                PreviewImage = "/Blog/images/blog2.jpg",
                Header = "Как выбрать корпус",
                BodyHtml = @"<p>Первоначально все корпуса компьютеров, совместимых с IBM PC, имели один и тот же типоразмер (Desktop) и были похожи друг на друга практически всем, даже цветом.
Хотя совместимые компьютеры производило множество различных компаний, не связанных никакими лицензиями, нарушить заданный IBM негласный стандарт не решался никто. И светло-серые «чемоданы» с монитором сверху надолго прописались на столах офисов и кабинетов.
Первый, отличный от оригинала, типоразмер Tower (позже названный Full Tower) появился в 1996, через 15 лет после выхода на рынок IBM PC. Первоначально такие корпуса предназначались серверам и другим сборкам повышенной мощности: высокая «башня» обеспечивала куда лучшие условия вентиляции, чем плоский настольный корпус.
Новый корпус понравился многим, но высокая цена и излишний для домашних компьютеров внутренний объем помешали его широкому распространению. Однако интерес к новому типоразмеру был замечен производителями. Это привело к появлению стандарта Mid-Tower, быстро вытеснившего Desktop и ставшего основным массовым корпусом еще на несколько лет. И вплоть до середины «нулевых» весь выбор сводился к различным вариациям этих трех типоразмеров.</p>",
            });
            _Blogs.Add(new BlogPost
            {
                Date=DateTime.Now,
                Id=3,
                ImageBackground= "/Blog/images/blog3.jpg",
                PreviewImage = "/Blog/images/blog3.jpg",
                Header = "Что такое техпроцесс в микрочипах и как он влияет на производство полупроводников",
                BodyHtml= @"<p><strong>Одна из главных характеристик процессоров и других микрочипов — техпроцесс. Что означает этот термин и насколько он влияет на производительность — разберемся в этом блоге.</strong></p>
<h2>Что такое техпроцесс</h2>
<p>Ключевым элементом практически каждой вычислительной схемы является транзистор. Это полупроводниковый элемент, который служит для управления токами. Из транзисторов собираются основные логические элементы, а на их основе создаются различные комбинационные схемы и уже непосредственно процессоры.</p>"
            });

        }
        public int Add(BlogPost blogPost)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BlogPost> Get()
        {
            return _Blogs;
        }

        public BlogPost Get(int id)
        {
            return _Blogs.FirstOrDefault(item => item.Id == id);
        }

        public void Update(BlogPost blogPost)
        {
            throw new NotImplementedException();
        }
    }
}
