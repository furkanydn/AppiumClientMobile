using static AppiumClientMobile.Properties.Capabilities;

namespace AppiumClientMobile.Enums
{
    public static class GeneralDesiredCaps
    {
        public static readonly string AppPathAndroid =
            @"C:\Users\FurkanAYDIN\source\repos\AppiumClientMobile\AppiumClientMobile\Resources\motivistv5.apk";
        
        // Since the paths of the application packages on the Mac side are different, it will be continued like this for now.
        public static readonly string AppPathAndroidMac = GeneralCapabilities_Android_AppPath_OnMac;
        public static readonly string AppPathIosMac = GeneralCapabilities_Ios_AppPath_OnMac;
        public static readonly string AppPackage = GeneralCapabilities_Android_AppPackageName;
        public static readonly string AppWaitActivity = GeneralCapabilities_Android_AppWaitActivity; // Don't Change This !
        public static readonly string PlatformNameAndroid = GeneralCapabilities_Android_PlatformName;
        public static readonly string PlatformNameIos = GeneralCapabilities_Ios_PlatformName;
        public static readonly string PlatformVersionAndroid = GeneralCapabilities_Android_PlatformVersion;
        public static readonly string PlatformVersionIos = GeneralCapabilities_Ios_PlatformVersion;
        public static readonly string DeviceNameAndroid = GeneralCapabilities_Android_DeviceName;
        public static readonly string DeviceNameIos = GeneralCapabilities_Ios_DeviceName;
        public static readonly string OrientationPortrait = GeneralCapabilities_AnyDevice_OrientationPortrait;

        public static readonly string BundleId = GeneralCapabilities_Ios_BundleId;

        public static readonly bool NoReset = true;
        public static readonly bool FullReset = false;

        // iOS tarafındaki hataların çözümü olarak dışarıdan ekleme yapılmıştır.
        public static readonly string WdaBaseUrl = GeneralCapabilities_Ios_WdaBaseUrl;
    }
}