using Autofac;
using Autofac.Integration.Mvc;
using Crud_Solid1.Models.Db;
using Crud_Solid1.Models.TablaViewModels;
using Crud_Solid1.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Crud_Solid1
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            RegisterDependencies(); // Llamamos al método de configuración de dependencias
        }

        private void RegisterDependencies()
        {
            var builder = new ContainerBuilder();

            // Registramos las implementaciones de las interfaces
            builder.RegisterType<DatosDB>().As<ICreate<UserViewModel>>().As<IRead<UserTableViewModel>>()
                .As<IUpdate<UserViewModel>>().As<IDelete>();

            // Registramos los controladores MVC
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            // Construimos el contenedor de IoC
            var container = builder.Build();

            // Configuramos la resolución de dependencias de MVC para usar Autofac(Debo instalar el Autofac desde el administrador paquetes NuGet)
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
