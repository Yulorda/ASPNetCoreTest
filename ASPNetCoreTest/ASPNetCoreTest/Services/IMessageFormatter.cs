namespace ASPNetCoreTest.Services
{
    public interface IMessageFormatter
    {
        void Add(string message);
        string GetResult();
    }
}