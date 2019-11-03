using System;
using System.Reflection;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Microsoft.Owin;
using Owin;
using WebLaptop_Data;
using WebLaptop_Data.Infrastructure;
using WebLaptop_Data.Repositories;
using WebLaptop_Service;

[assembly: OwinStartup(typeof(WebLaptop.App_Start.Startup))]

namespace WebLaptop.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigAutofac(app);
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
        }

        public void ConfigAutofac(IAppBuilder app)
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly()); //Register WebApi Controllers
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            builder.RegisterType<DbFactory>().As<IDbFactory>().InstancePerRequest();
            builder.RegisterType<WebLaptopDbContext>().AsSelf().InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(PostCategoryRepository).Assembly).Where(t => t.Name.EndsWith("Repository")).AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterAssemblyTypes(typeof(PostCategoryService).Assembly).Where(t => t.Name.EndsWith("Service")).AsImplementedInterfaces().InstancePerRequest();


            Autofac.IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver((IContainer)container); //Set the WebApi DependencyResolver
        }
    }
}
