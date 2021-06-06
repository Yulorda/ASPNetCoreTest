using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCoreTest.Services
{
    public class MessageFormatterServices
    {
        IMessageFormatter messageFormatter;

        private int i = 0;

        //ctor Inject
        public MessageFormatterServices(IMessageFormatter messageFormatter)
        {
            this.messageFormatter = messageFormatter;
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
