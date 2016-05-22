namespace Localwire.Graphinder.Algorithms.WorkerApi
{
    using System.Web;
    using System.Web.Http;
    using System.Web.Mvc;
    using System.Web.Routing;
    using Autofac;
    using Autofac.Integration.WebApi;

    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var builder = new ContainerBuilder();
            var config = GlobalConfiguration.Configuration;

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            builder.WithServicesRegistered()
                .WithControllersRegistered();
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            new GatewayConnection();
        }
    }
}
