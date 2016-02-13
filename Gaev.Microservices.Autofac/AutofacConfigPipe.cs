using System;
using System.Linq;
using Autofac;

namespace Gaev.Microservices.Autofac
{
    public class AutofacConfigPipe : ConfigPipe
    {
        Action<ContainerBuilder> config;
        public AutofacConfigPipe(IConfigPipe previous) : base(previous)
        {
        }

        public AutofacConfigPipe With(Action<ContainerBuilder> config)
        {
            this.config = config;
            return this;
        }

        public override ISetup Build()
        {
            var previousSetup = previous.Build();

            var builder = new ContainerBuilder();
            if (config != null) config(builder);
            var container = builder.Build();

            var setup = new Setup();
            setup.CopyFrom(previousSetup);
            setup.Extensions.Add(container);
            setup.IoC = new AutofacIoC(container);
            return setup;
        }
    }
}

namespace Gaev.Microservices
{
    using Gaev.Microservices.Autofac;
    public static class AutofacExt
    {
        public static AutofacConfigPipe UseAutofac(this IConfigPipe previous)
        {
            return new AutofacConfigPipe(previous);
        }
        public static IContainer AutofacIoC(this ISetup setup)
        {
            return setup.Extensions.OfType<IContainer>().FirstOrDefault();
        }
    }
}