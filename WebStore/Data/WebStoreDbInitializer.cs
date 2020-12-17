using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webstore.DAL.Context;

namespace WebStore.Data
{
    public class WebStoreDbInitializer
    {
        private readonly WebStoreDB _db;

        public WebStoreDbInitializer(WebStoreDB db)
        {
            _db = db;
        }
        public void Initialize()
        {

        }
    }
}
