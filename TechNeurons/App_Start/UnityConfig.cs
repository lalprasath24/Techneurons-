using System.Web.Mvc;
using TechNeurons.IRepository;
using TechNeurons.Models;
using TechNeurons.Repository;
using Unity;
using Unity.Mvc5;

namespace TechNeurons
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<IEmployeeRepository<Employee>,EmployeeRepository<Employee>>();
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

       
    }
}