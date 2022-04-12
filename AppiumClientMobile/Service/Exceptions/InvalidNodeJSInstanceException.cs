using System;
using System.Collections.Generic;
using System.Text;

namespace AppiumClientMobile.Service.Exceptions
{
    public class InvalidNodeJsInstanceException : Exception
    {
        public InvalidNodeJsInstanceException(string message, Exception exception) : base(message, exception)
        {

        }

        public InvalidNodeJsInstanceException(string message) : base(message)
        {

        }
    }
}
