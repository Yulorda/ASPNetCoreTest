using ASPNetCoreTest.Services;
using System.Text;

public class SmsMessanger : IMessageFormatter
{
    private StringBuilder result;

    public void Add(string message)
    {
        result.Append(message);
        result.Append(" ");
        if (result.Length > 50)
        {
            result.Clear();
            result.Append("Error#@%^$/");
        }
    }

    public string GetResult()
    {
        var temp = result.ToString();
        result.Clear();
        result.Append("/");
        return temp;
    }
}
