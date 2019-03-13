using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Routing;
using Microsoft.AspNet.FriendlyUrls;

namespace CentroBiologiaMolecularUCA
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            var settings = new FriendlyUrlSettings();
            routes.EnableFriendlyUrls(settings);
            routes.MapPageRoute("Login", "", "~/Login.aspx");
        }
    }
}
