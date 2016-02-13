namespace Gaev.Microservices
{
    public abstract class ConfigPipe : IConfigPipe
    {
        protected readonly IConfigPipe previous;

        public ConfigPipe(IConfigPipe previous)
        {
            this.previous = previous;
        }

        public virtual ISetup Build()
        {
            return previous?.Build();
        }
    }
}
