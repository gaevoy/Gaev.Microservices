namespace Gaev.Microservices
{
    public class NameConfigPipe : ConfigPipe
    {
        string name;
        public NameConfigPipe() : base(null)
        {
        }

        public NameConfigPipe HaveName(string name)
        {
            this.name = name;
            return this;
        }

        public NameConfigPipe Be(string name)
        {
            return HaveName(name);
        }

        public override ISetup Build()
        {
            return new Setup
            {
                Name = name
            };
        }
    }
}
