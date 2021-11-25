using System;
using static AppiumClientMobile.Properties.Capabilities;

namespace AppiumClientMobile.Enums
{
    public class GeneralDesiredCaps
    {
        // public static readonly string AppPathAndroid = @"C:\Users\FurkanAYDIN\source\repos\AppiumClientMobile\AppiumClientMobile\Resources\motivistv5.apk";

        // Since the paths of the application packages on the Mac side are different, it will be continued like this for now.
        public static readonly object AppPathAndroidMac = GeneralCapabilities_Android_AppPath_OnMac;
        public static readonly object AppPathIosMac = GeneralCapabilities_Ios_AppPath_OnMac;
        public static readonly object AppPackage = GeneralCapabilities_Android_AppPackageName;
        public static readonly object AppWaitActivity = GeneralCapabilities_Android_AppWaitActivity; // Don't Change This !
        public static readonly object PlatformVersionAndroid = GeneralCapabilities_Android_PlatformVersion;
        public static readonly object PlatformVersionIos = GeneralCapabilities_Ios_PlatformVersion;
        public static readonly object DeviceNameAndroid = GeneralCapabilities_Android_DeviceName;
        public static readonly object DeviceNameIos = GeneralCapabilities_Ios_DeviceName;
        public static readonly object OrientationPortrait = GeneralCapabilities_AnyDevice_OrientationPortrait;

        public static readonly object BundleId = GeneralCapabilities_Ios_BundleId;

        public const bool NoReset = true;
        public const bool FullReset = false;

        // iOS tarafındaki hataların çözümü olarak dışarıdan ekleme yapılmıştır.
        public static readonly string WdaBaseUrl = GeneralCapabilities_Ios_WdaBaseUrl;
        
        public static readonly byte AppiumMobilePlatform = Convert.ToByte(GeneralCapabilities_Hybrid_MobilePlatform);
    }

    /// <inheritdoc />
    internal class GeneralDesiredCapsImpl : GeneralDesiredCaps
    {
        
    }
}