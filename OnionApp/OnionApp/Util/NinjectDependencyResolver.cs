using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using OnionApp.Domain.Interfaces;
using OnionApp.Services.Interfaces;
using OnionApp.Infrastructure.Data;
using OnionApp.Infrastructure.Business;

namespace OnionApp.Util
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        private void AddBindings()
        {
            kernel.Bind<IBookRepository>().To<BookRepository>();
            kernel.Bind<IOrder>().To<CachOrder>();
        }
    }
}