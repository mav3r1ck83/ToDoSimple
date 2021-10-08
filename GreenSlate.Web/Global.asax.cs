using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using GreenSlate.Web.AutoMapperConfig;

namespace GreenSlate.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var razorEngine = ViewEngines.Engines.OfType<RazorViewEngine>().First();
            razorEngine.ViewLocationFormats = razorEngine.ViewLocationFormats.Concat(new string[]
            {
                "~/SPA/Views/{1}/{0}.cshtml",
                "~/SPA/Views/{1}/{0}.vbhtml",
                "~/SPAP/Views/Shared/{0}.cshtml",
                "~/SPA/Views/Shared/{0}.vbhtml"
            }).ToArray();
            razorEngine.PartialViewLocationFormats = razorEngine.PartialViewLocationFormats.Concat(new string[]
{
                "~/SPA/Views/{1}/{0}.cshtml",
                "~/SPA/Views/{1}/{0}.vbhtml",
                "~/SPA/Views/Shared/{0}.cshtml",
                "~/SPA/Views/Shared/{0}.vbhtml"
            }).ToArray();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AutoMapper.Mapper.Initialize(cfg => cfg.AddProfile<AutomapperProfile>());
            UnityConfig.RegisterComponents();
        }
    }
}
