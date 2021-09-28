using System;
using System.Collections.Generic;
using System.Text;

namespace AppiumClientMobile.Service.Options
{
    /*
     * All flags are optional, but some are required in conjunction with certain others.
     * The full list is available here: https://appium.io/docs/en/writing-running-appium/server-args/
     * Android specific arguments are marked by (Android)
     */
    public sealed class AndroidOptionList : BaseOptionList
    {
        public static KeyValuePair<string, string> BootStrapPort(string value) =>
            GetKeyValuePairUsingDefaultValue("--bootstrap-port", value, "4724");

        public static KeyValuePair<string, string> SuppressAdbKillServer() =>
            new KeyValuePair<string, string>("--suppress-adb-kill-server", string.Empty);

        public static KeyValuePair<string, string> ChromeDriverPort(string value) =>
            GetKeyValuePairUsingDefaultValue("--chromedriver-port", value, "9515");

        public static KeyValuePair<string, string> ChromeDriverExetable(string value) =>
            GetKeyValuePair("--chromedriver-executable	", value);
    }
}
