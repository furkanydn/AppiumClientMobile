using System;
using System.Collections.Generic;
using System.IO;

namespace AppiumClientMobile.Enums
{
    public class GeneralDesiredCaps
    {
        public static string AppNameIos = "motivistv5.ipa";

        public static readonly string AppPathAndroid =
            @"C:\Users\FurkanAYDIN\source\repos\AppiumClientMobile\AppiumClientMobile\Resources\motivistv5.apk";
           // Path.Combine(Environment.CurrentDirectory, @"Resources\", AppNameAndroid);
        public static readonly string AppPathIos =
            Path.Combine(Environment.CurrentDirectory, @"Resources\", AppNameIos);

        public static readonly string AppPackage = "com.motivist.development";

        public static readonly string AppWaitActivity = "*";

        public static readonly bool NoReset = true;
        public static readonly bool FullReset = false;

        public static readonly string PlatformNameAndroid = "Android";
        public static readonly string PlatformNameIos = "iOS";

        public static readonly string PlatformVersionAndroid = "8.1";
        public static readonly string PlatformVersionIos = "12.5.5";

        public static readonly string DeviceNameAndroid = "Pixel3";
        public static readonly string DeviceNameIos = "iPhone X";

        public static readonly string OrientationPortrait = "PORTRAIT";
        public static readonly string OrientationLandscape = "LANDSCAPE";
    }
}