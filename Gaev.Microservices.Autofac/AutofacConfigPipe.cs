namespace Gaev.Microservices.Autofac
{
    public class AutofacConfigPipe : ConfigPipe
    {
        public AutofacConfigPipe(IConfigPipe previous) : base(previous)
        {
        }

        public override ISetup Build()
        {
            return previous.Build();
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
    }
}