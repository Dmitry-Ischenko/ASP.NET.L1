using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Models;

namespace WebStore.Infrastructure.Interfaces
{
    public interface IBlogsData
    {
        IEnumerable<BlogPost> Get();

        BlogPost Get(int id);

        int Add(BlogPost blogPost);

        void Update(BlogPost blogPost);

        bool Delete(int id);

    }
}
