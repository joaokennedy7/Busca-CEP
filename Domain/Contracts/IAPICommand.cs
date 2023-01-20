namespace CEPDomain.Contracts
{
    public interface IAPICommand<TBody> : IAPICommand
    {
        TBody Body { get; }
    }

    public interface IAPICommand
    {
        string EndpointPath { get; }
    }
}
