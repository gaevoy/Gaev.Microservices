namespace Gaev.Microservices
{
    public class Setup : ISetup
    {
        public string Name { get; set; }
        public IIoC IoC { get; set; }
        public ILogger Logger { get; set; }
        public IMonitor Monitor { get; set; }

        protected virtual void CopyTo(Setup target)
        {
            target.Name = Name;
            target.IoC = IoC;
            target.Logger = Logger;
            target.Monitor = Monitor;
        }

        public void Dispose()
        {
            if (IoC != null) IoC.Dispose();
        }
    }
}