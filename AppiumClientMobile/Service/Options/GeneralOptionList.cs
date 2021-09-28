using System.Collections.Generic;

namespace AppiumClientMobile.Service.Options
{
    /*
     * All flags are optional, but some are required in conjunction with certain others.
     * The full list is available here: https://appium.io/docs/en/writing-running-appium/server-args/
     */
    public class GeneralOptionList : BaseOptionList
    {
        // Enter REPL mode
        public static KeyValuePair<string, string> Shell(string value) => GetKeyValuePair("--shell", value);

        // callback IP Address (default: same as --address)
        public static KeyValuePair<string, string> CallbackAddress(string value) =>
            new KeyValuePair<string, string>("--callback-address", value);

        // callback port (default: same as port)
        public static KeyValuePair<string, string> CallbackPort(string value) =>
            new KeyValuePair<string, string>("--callback-port", value);

        // 	Enables session override (clobbering)
        public static KeyValuePair<string, string> OverrideSession() =>
            new KeyValuePair<string, string>("--session-override", string.Empty);

        // Pre-launch the application before allowing the first session (Requires --app and, for Android, --app-pkg and --app-activity)
        public static KeyValuePair<string, string> PreLaunch() =>
            new KeyValuePair<string, string>("--pre-launch", string.Empty);

        // Set the server log level for console and logfile (specified as console-level:logfile-level, with both being the same if only one value is supplied).
        // Possible values are debug, info, warn, error, which are progressively less verbose.
        public static KeyValuePair<string, string> LogLevel(string value) =>
            GetKeyValuePairUsingDefaultValue("--log-level", value, "debug");

        // Show timestamps in console output	
        public static KeyValuePair<string, string> LogTimeStamp() =>
            new KeyValuePair<string, string>("--log-timestamp", string.Empty);

        // Use local timezone for timestamps	
        public static KeyValuePair<string, string> LocalTimeZone() =>
            new KeyValuePair<string, string>("--local-timezone", string.Empty);

        // Do not use colors in console output	
        public static KeyValuePair<string, string> LogNoColors() =>
            new KeyValuePair<string, string>("--log-no-colors", string.Empty);

        // Also send log output to this HTTP listener
        public static KeyValuePair<string, string> WebHook(string value) => GetKeyValuePair("--webhook", value);

        // Configuration JSON file to register appium with selenium grid
        public static KeyValuePair<string, string> NodeConfig(string value) => GetKeyValuePair("--nodeconfig", value);

        // IP Address of robot
        public static KeyValuePair<string, string> RobotAddress(string value) =>
            GetKeyValuePairUsingDefaultValue("--robot-address", value, "0.0.0.0");

        // Port for robot
        public static KeyValuePair<string, string> RobotPort(string value) =>
            GetKeyValuePairUsingDefaultValue("--robot-port", value, "4242");

        // 	Show info about the appium server configuration and exit
        public static KeyValuePair<string, string> ShowConfig() =>
            new KeyValuePair<string, string>("--show-config", string.Empty);

        // Bypass Appium's checks to ensure we can read/write necessary files
        public static KeyValuePair<string, string> NoPermsCheck() =>
            new KeyValuePair<string, string>("--no-perms-check", string.Empty);

        // Cause sessions to fail if desired caps are sent in that Appium does not recognize as valid for the selected device
        public static KeyValuePair<string, string> StrictCaps() =>
            new KeyValuePair<string, string>("--strict-caps", string.Empty);

        // Absolute path to directory Appium can use to manage temporary files, like built-in iOS apps it needs to move around. On *nix/Mac defaults to /tmp, on Windows defaults to C:\Windows\Temp
        public static KeyValuePair<string, string> TMP(string value) => GetKeyValuePair("--tmp", value);

        // Add exaggerated spacing in logs to help with visual inspection
        public static KeyValuePair<string, string> DebugLogSpacing() =>
            new KeyValuePair<string, string>("--debug-log-spacing", string.Empty);

        // Add long stack traces to log entries. Recommended for debugging only.
        public static KeyValuePair<string, string> AsyncTrace() =>
            new KeyValuePair<string, string>("--async-trace", string.Empty);
    }
}