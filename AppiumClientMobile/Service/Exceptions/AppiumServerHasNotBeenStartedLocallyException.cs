using System;
using System.Collections.Generic;
using System.Text;

namespace AppiumClientMobile.Service.Exceptions
{
    public abstract class AppiumServerHasNotBeenStartedLocallyException : Exception
    {
        protected AppiumServerHasNotBeenStartedLocallyException(string message, Exception exception) : base(message, exception)
        {

        }

        protected AppiumServerHasNotBeenStartedLocallyException(string message) : base(message)
        {

        }
    }
}
