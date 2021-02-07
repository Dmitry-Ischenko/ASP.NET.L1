using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webstore.Interfaces
{
    public static class WebAPI
    {
        private const string api = "api/";

        public const string Version = "v1";

        public const string Products = api + Version + "api/products";
        public const string Values = api + Version + "api/values";
        public const string Employees = api + Version + "api/employees";
        public const string Orders = api + Version + "api/orders";

        public static class Identity
        {
            public const string User = api + Version + "/users";
            public const string Role = api + Version + "/roles";
        }
    }
}
