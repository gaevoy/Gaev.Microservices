using Topshelf;

namespace Gaev.Microservices
{
    public class TopshelfHost
    {
        public static void Boot<T>(string serviceName = "") where T : class, IMicroservice, new()
        {
            HostFactory.Run(x =>
            {
                x.Service<T>(s =>
                {
                    s.ConstructUsing(_ => new T());
                    s.WhenStarted(tc => tc.Start());
                    s.WhenStopped(tc => tc.Stop());
                });
                x.RunAsLocalSystem();
                x.SetServiceName(serviceName);
            });
        }
    }
}
