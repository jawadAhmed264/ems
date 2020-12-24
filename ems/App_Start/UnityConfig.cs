using ems.Service.ServiceImplimentation;
using ems.Service.ServiceInterface;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace ems
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            container.RegisterType<IDepartmentService, DepartmentService>();
            container.RegisterType<IEmployeeService, EmployeeService>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}