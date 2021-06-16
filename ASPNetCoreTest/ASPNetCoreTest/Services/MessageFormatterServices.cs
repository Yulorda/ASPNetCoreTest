using ASPNetCoreTest.Services.Middleware;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCoreTest.Services
{
    public class MessageFormatterServices
    {
        IMessageFormatter messageFormatter;
        TimeService timeService;

        private int i = 0;

        //ctor Inject
        public MessageFormatterServices(IMessageFormatter messageFormatter, TimeService timeService)
        {
            this.messageFormatter = messageFormatter;
            this.timeService = timeService;
        }


        public string GetResult()
        {
            return messageFormatter.GetResult();
        }

        public void AddMessage(string message)
        {
            message = i++ + message;
            messageFormatter.Add(message);
        }
    }
}
