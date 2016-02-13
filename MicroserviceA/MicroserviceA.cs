using Gaev.Microservices;

namespace MicroserviceA
{
    class Program
    {
        static void Main() => TopshelfHost.Boot<MicroserviceA>(serviceName: "MicroserviceA");
    }

    class MicroserviceA : Microservice
    {
        protected override ISetup Starting() =>
            Microservice
                .Will()
                .Be("A")
                .UseAutofac()
                .Build();
    }
}