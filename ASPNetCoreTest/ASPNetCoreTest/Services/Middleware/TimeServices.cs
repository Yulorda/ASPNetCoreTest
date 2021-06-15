using System.Collections.Generic;
using System.Linq;

namespace ASPNetCoreTest.Services.Middleware
{
    public class TimeService
    {
        public TimeService()
        {
            Time = System.DateTime.Now.ToString("hh:mm:ss");
        }
        public string Time { get; }
    }
}
