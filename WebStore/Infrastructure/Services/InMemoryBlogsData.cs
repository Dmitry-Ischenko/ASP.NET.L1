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
                PreviewImage = "images/blog_1.jpg",
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
