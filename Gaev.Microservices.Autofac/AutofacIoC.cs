using System;
using Autofac;

namespace Gaev.Microservices.Autofac
{
    public class AutofacIoC : IIoC
    {
        readonly IContainer container;

        public AutofacIoC(IContainer container)
        {
            this.container = container;
        }

        public void Dispose()
        {
            container.Dispose();
        }

        public T Resolve<T>() where T : class
        {
            return container.Resolve<T>();
        }

        public IIoC Register<T>(Func<IIoC, T> func)
        {
            var builder = new ContainerBuilder();
            builder.Register(c => func(this)).As<T>();
            builder.Update(container);
            return this;
        }
    }
}