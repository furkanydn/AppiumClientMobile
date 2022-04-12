using System;
using System.Collections.Generic;
using System.Text;

namespace AppiumClientMobile.Service.Options
{
    public class BaseOptionList
    {
        protected static KeyValuePair<string, string> GetKeyValuePair(string argument, string value)
        {
            return string.IsNullOrEmpty(value)
                ? throw new ArgumentException(
                    $"The argument {argument} requires not empty value")
                : new KeyValuePair<string, string>(argument, value);
        }

        protected static KeyValuePair<string, string> GetKeyValuePairUsingDefaultValue(string argument, string value,
            string defaultValue)
        {
            return string.IsNullOrEmpty(value) ? new KeyValuePair<string, string>(argument, defaultValue) : new KeyValuePair<string, string>(argument, value);
        }
    }
}
