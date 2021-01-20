using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Infrastructure.Interfaces;
using WebStore.Models;
using WebStore.Service;

namespace WebStore.Infrastructure.Services
{
    public class InMemoryBlogsData: IBlogsData
    {
        private IEnumerable<BlogPost> _Blogs = TestDB.Blogs;

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
