using System;
using System.Collections.Generic;
using System.Text;

namespace AppiumClientMobile.Service.Exceptions
{
    public class AppiumServerHasNotBeenStartedLocallyException : Exception
    {
        public AppiumServerHasNotBeenStartedLocallyException(string message, Exception exception) : base(message, exception)
        {

        }

        public AppiumServerHasNotBeenStartedLocallyException(string message) : base(message)
        {

        }
    }
}
