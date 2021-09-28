using System.Collections.Generic;

namespace AppiumClientMobile.Service.Options
{
    /*
     * All flags are optional, but some are required in conjunction with certain others.
     * The full list is available here: https://appium.io/docs/en/writing-running-appium/server-args/
     * IOS specific arguments are marked by (IOS)
     */
    public class IosOptionList : BaseOptionList
    {
        // Abs path to compiled .ipa file
        public static KeyValuePair<string, string> Ipa(string value) => GetKeyValuePair("--ipa", value);

        // How many times to retry launching Instruments before saying it crashed or timed out
        public static KeyValuePair<string, string> BackEndRetries(string value) =>
            GetKeyValuePairUsingDefaultValue("--backend-retries", value, "3");

        // Use the safari app
        public static KeyValuePair<string, string> Safari() =>
            new KeyValuePair<string, string>("--safari", string.Empty);

        // (IOS-Simulator-Only) use the default simulator that instruments launches on its own
        public static KeyValuePair<string, string> DefaultDevice() =>
            new KeyValuePair<string, string>("--default-device", string.Empty);

        // Use the iPhone Simulator no matter what the app wants
        public static KeyValuePair<string, string> ForceIphoneSimulator() =>
            new KeyValuePair<string, string>("--force-iphone", string.Empty);

        // Use the iPad Simulator no matter what the app wants
        public static KeyValuePair<string, string> ForceIpadSimulator() =>
            new KeyValuePair<string, string>("--force-ipad", string.Empty);

        // .tracetemplate file to use with Instruments
        public static KeyValuePair<string, string> TraceTemplate(string value) =>
            GetKeyValuePair("--tracetemplate", value);

        // Path to instruments binary
        public static KeyValuePair<string, string> Instruments(string value) => GetKeyValuePair("--instruments", value);

        // Xcode 6 has a bug on some platforms where a certain simulator can only be launched without error if all other simulator devices are first deleted.
        // This option causes Appium to delete all devices other than the one being used by Appium.
        // Note that this is a permanent deletion, and you are responsible for using simctl or xcode to manage the categories of devices used with Appium.
        public static KeyValuePair<string, string> IsolateSimDevice() =>
            new KeyValuePair<string, string>("--isolate-sim-device", string.Empty);

        // Absolute path to directory Appium use to save ios instruments traces, defaults to /appium-instruments
        public static KeyValuePair<string, string> TraceDirectory(string value) =>
            GetKeyValuePair("--trace-dir", value);

        // Local port used for communication with ios-webkit-debug-proxy
        public static KeyValuePair<string, string> WebkitDebugProxyPort(string value) =>
            GetKeyValuePair("--webkit-debug-proxy-port", value);
    }
}