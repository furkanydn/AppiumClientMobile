using System;
using System.Collections.Generic;
using System.Text;

namespace AppiumClientMobile.Service.Exceptions
{
    public class InvalidNodeJSInstanceException : Exception
    {
        public InvalidNodeJSInstanceException(string message, Exception exception) : base(message, exception)
        {

        }

        public InvalidNodeJSInstanceException(string message) : base(message)
        {

        }
    }
}
