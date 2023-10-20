using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace Shared
{
    public class UrlHelper
    {
        private static string GetUrl()
        {
            var url = System.Configuration.ConfigurationManager.AppSettings["url"];
            return url;
        }

        public static class Api
        {
            public static Uri CustomerApi => new Uri($"{GetUrl()}api/");
        }

        public static class Controller
        {
            public const string Customer = "Customer/";
            public const string CustomerTransaction = "CustomerTransaction/";
        }
    }
}
