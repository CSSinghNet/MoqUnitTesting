using DemoAPITest.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Unity;
using Unity.AspNet.WebApi;

namespace DemoAPITest.App_Start
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            container.RegisterType<IDataRepository, DataRepository>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}