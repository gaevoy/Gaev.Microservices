using System.Collections.Generic;

namespace Gaev.Microservices
{
    public class Setup : ISetup
    {
        public Setup()
        {
            Extensions = new List<object>();
        }

        public string Name { get; set; }
        public IIoC IoC { get; set; }
        public ILogger Logger { get; set; }
        public IMonitor Monitor { get; set; }
        public IList<object> Extensions { get; set; }

        public virtual void CopyFrom(ISetup src)
        {
            Name = src.Name;
            IoC = src.IoC;
            Logger = src.Logger;
            Monitor = src.Monitor;
            Extensions = src.Extensions;
        }

        public void Dispose()
        {
            if (IoC != null) IoC.Dispose();
        }
    }
}