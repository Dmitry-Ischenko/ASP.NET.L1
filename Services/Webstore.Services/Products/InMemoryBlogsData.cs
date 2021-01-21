using System;
using System.Collections.Generic;
using System.Linq;
using Webstore.Interfaces.Services;
using WebStore.Domain.Models;
using Webstore.Services.Data;

namespace Webstore.Services.Products
{
    public class InMemoryBlogsData : IBlogsData
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
