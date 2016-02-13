using System;

namespace Gaev.Microservices
{
    public abstract class Microservice : MarshalByRefObject, IMicroservice
    {
        readonly object sync = new object();
        ISetup setup;

        public void Start()
        {
            lock (sync)
                if (setup == null)
                    setup = Starting();
        }

        public void Stop()
        {
            lock (sync)
                if (setup != null)
                {
                    Stopping(setup);
                    setup.Dispose();
                    setup = null;
                }
        }

        protected abstract ISetup Starting();
        protected virtual void Stopping(ISetup setup) { }

        public static NameConfigPipe Will()
        {
            return new NameConfigPipe();
        }
    }
}
