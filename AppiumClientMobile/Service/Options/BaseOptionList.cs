using System;
using System.Collections.Generic;
using System.Text;

namespace AppiumClientMobile.Service.Options
{
    public class BaseOptionList
    {
        protected static KeyValuePair<string, string> GetKeyValuePair(string argument, string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException(
                    $"The argument {argument} requires not empty value");
            }

            return new KeyValuePair<string, string>(argument, value);
        }

        protected static KeyValuePair<string, string> GetKeyValuePairUsingDefaultValue(string argument, string value,
            string defaultValue)
        {
            if (string.IsNullOrEmpty(value))
            {
                return new KeyValuePair<string, string>(argument, defaultValue);
            }
            else
            {
                return new KeyValuePair<string, string>(argument, value);
            }
        }
    }
}
