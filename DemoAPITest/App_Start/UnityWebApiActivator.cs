using DemoAPITest.App_Start;
using DemoAPITest.Repository;
using System.Web.Http;
using Unity;
using Unity.AspNet.WebApi;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(DemoAPITest.UnityWebApiActivator), nameof(DemoAPITest.UnityWebApiActivator.Start))]

namespace DemoAPITest
{
    /// <summary>
    /// Provides the bootstrapping for integrating Unity with WebApi when it is hosted in ASP.NET.
    /// </summary>
    public static class UnityWebApiActivator
    {
        /// <summary>
        /// Integrates Unity when the application starts.
        /// </summary>
        public static void Start() 
        {
            // Use UnityHierarchicalDependencyResolver if you want to use
            // a new child container for each IHttpController resolution.
            // var resolver = new UnityHierarchicalDependencyResolver(UnityConfig.Container);
            var container = new UnityContainer();
            container.RegisterType<IDataRepository, DataRepository>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }

       
    }
}