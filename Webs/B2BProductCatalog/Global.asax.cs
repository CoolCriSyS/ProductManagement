using System.Web.Mvc;
using System.Web.Routing;

namespace B2BProductCatalog
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Catalog", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            log4net.Config.XmlConfigurator.Configure();
            //AreaRegistration.RegisterAllAreas();
            RegisterRoutes(RouteTable.Routes);
        }

        protected void Application_BeginRequest()
        {
            //TODO: Do I want to expose the NHibernateSessionFactory for these methods?
            //See http://stackoverflow.com/questions/10766662/optimizing-nhibernate-session-factory-startup-time-of-webapp-really-slow
        }

        protected void Application_EndRequest()
        {
            
        }
    }
}