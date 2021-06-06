using ASPNetCoreTest.Services;
using System.Text;

public class EmailMessanger : IMessageFormatter
{
    private StringBuilder result;

    public EmailMessanger()
    {
        result = new StringBuilder();
        result.Append("/");
    }

    public void Add(string message)
    {
        result.Append(message);
        result.Append("@gmail.com/ /");
    }

    public string GetResult()
    {
        var temp = result.ToString();
        result.Clear();
        result.Append("/");
        return temp;
    }
}
