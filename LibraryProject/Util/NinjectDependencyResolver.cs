using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Services;
using Ninject;
using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;
using System.Web.Mvc;

namespace LibraryProject.Util
{
    public class NinjectDependencyResolver : NinjectDependencyScope, System.Web.Http.Dependencies.IDependencyResolver, System.Web.Mvc.IDependencyResolver
    {
        private IKernel kernel;
        public NinjectDependencyResolver(IKernel kernelParam):base(kernelParam)
        {
            kernel = kernelParam;
            //AddBindings();
        }

        public IDependencyScope BeginScope()
        {
            return new NinjectDependencyScope(kernel.BeginBlock());
        }

        //public object GetService(Type serviceType)
        //{
        //    return kernel.TryGet(serviceType);
        //}
        //public IEnumerable<object> GetServices(Type serviceType)
        //{
        //    return kernel.GetAll(serviceType);
        //}
        //private void AddBindings()
        //{
        //    kernel.Bind<IHomeService>().To<HomeService>();          
        //}
    }
}