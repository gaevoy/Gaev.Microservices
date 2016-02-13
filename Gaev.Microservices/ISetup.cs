using System;

namespace Gaev.Microservices
{
    public interface ISetup: IDisposable
    {
        string Name { get; }
        IIoC IoC { get; }
        ILogger Logger { get; }
        IMonitor Monitor { get; }
    }
}