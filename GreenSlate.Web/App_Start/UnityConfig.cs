using System.Web.Mvc;
using Unity;
using Unity.Mvc5;
using GreenSlate.Database.Interfaces;
using GreenSlate.Database.Repositories;
using GreenSlate.Business.Interfaces;
using GreenSlate.Business.Services;
using GreenSlate.Business.CacheHelper;


namespace GreenSlate.Web
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<ITodoService, TodoService>();
            container.RegisterType<IToDoRepository, ToDoRepository>();
            container.RegisterType<IUserRepository, UserRepository>();
            container.RegisterType<IUserService, UserService>();
            container.RegisterType<IGlobalCachingProvider, GlobalCachingProvider>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}