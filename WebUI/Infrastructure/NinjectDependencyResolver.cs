using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Domian.Abstract;
using Domian.BusinessRepositories;
using Ninject;

namespace WebUI.Infrastructure
{

    public class NinjectDependencyResolver: IDependencyResolver
    {
        private readonly IKernel _kernel;

        public NinjectDependencyResolver(IKernel kernel)
        {
            _kernel = kernel;
            AddBinding();
        }

        /// <summary>
        /// Create a binding between Database and Concrete Entities
        /// </summary>
        private void AddBinding()
        {
            _kernel.Bind<ICustomerRepository>().To<EfCustomerRepository>();
        }

        public object GetService(Type serviceType)
        {
            return _kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _kernel.GetAll(serviceType);
        }
    }
}