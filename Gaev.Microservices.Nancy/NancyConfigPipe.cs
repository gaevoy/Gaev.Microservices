namespace Gaev.Microservices.Nancy
{
    public class NancyConfigPipe : ConfigPipe
    {
        public NancyConfigPipe(IConfigPipe previous) : base(previous)
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
    using Gaev.Microservices.Nancy;
    public static class NancyExt
    {
        public static NancyConfigPipe UseNancy(this IConfigPipe previous)
        {
            return new NancyConfigPipe(previous);
        }
    }
}