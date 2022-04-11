#nullable enable
using System;
using AppiumClientMobile.Enums;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Enums;

namespace AppiumClientMobile.helpers
{
    public static class Caps
    {
        /// <summary>
        /// Motivist brings the capabilities for the application.
        /// </summary>
        /// <param name="os">Mobile operating system</param>
        /// <param name="appRequired">If there is no application, this is the necessary detail for installation at first.</param>
        /// <returns>Motivist android capabilities</returns>
        public static AppiumOptions GetMotivistCapabilities(Os os, bool appRequired)
        {
            var capabilities = new AppiumOptions();
            switch (os)
            {
                case Os.Android:
                    capabilities.AddAdditionalCapability("platformName", MobilePlatform.Android);
                    capabilities.AddAdditionalCapability("appium:platformVersion",
                        GeneralDesiredCaps.PlatformVersionAndroid);
                    capabilities.AddAdditionalCapability("appium:deviceName", GeneralDesiredCaps.DeviceNameAndroid);
                    capabilities.AddAdditionalCapability("appium:automationName", AutomationEngineName.UiAutomator2);
                    if (appRequired)
                        capabilities.AddAdditionalCapability("appium:app", GeneralDesiredCaps.AppPathAndroidMac);
                    capabilities.AddAdditionalCapability("appPackage", GeneralDesiredCaps.AppPackage);
                    capabilities.AddAdditionalCapability("appWaitActivity", GeneralDesiredCaps.AppWaitActivity);
                    capabilities.AddAdditionalCapability("orientation", GeneralDesiredCaps.OrientationPortrait);
                    capabilities.AddAdditionalCapability("noReset", GeneralDesiredCaps.NoReset);
                    capabilities.AddAdditionalCapability("fullReset", GeneralDesiredCaps.FullReset);
                    break;
                case Os.iOS:
                    capabilities.AddAdditionalCapability("platformName", MobilePlatform.IOS);
                    capabilities.AddAdditionalCapability("appium:platformVersion",
                        GeneralDesiredCaps.PlatformVersionIos);
                    capabilities.AddAdditionalCapability("appium:deviceName", GeneralDesiredCaps.DeviceNameIos);
                    capabilities.AddAdditionalCapability("appium:automationName", AutomationEngineName.XcuiTest);
                    if (appRequired)
                        capabilities.AddAdditionalCapability("appium:app", GeneralDesiredCaps.AppPathIosMac);
                    capabilities.AddAdditionalCapability("appium:wdaBaseUrl", GeneralDesiredCaps.WdaBaseUrl);
                    capabilities.AddAdditionalCapability("noReset", GeneralDesiredCaps.NoReset);
                    capabilities.AddAdditionalCapability("bundleId", GeneralDesiredCaps.BundleId);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(os), os, null);
            }
            return capabilities;
        }

        public enum Os
        {
            Android,
            // ReSharper disable once InconsistentNaming
            iOS
        }

        public static AppiumOptions GetYuruBeIstanbulCapabilities(Os os,bool appRequired,string? activity=null)
        {
            var capabilities = new AppiumOptions();
            switch (os)
            {
                case Os.Android:
                    capabilities.AddAdditionalCapability("platformName", MobilePlatform.Android);
                    capabilities.AddAdditionalCapability("appium:platformVersion", "11");
                    capabilities.AddAdditionalCapability("appium:deviceName", "Pixel3s");
                    capabilities.AddAdditionalCapability("appium:automationName","UIAutomator2");
                    if (appRequired)
                        capabilities.AddAdditionalCapability("appium:app",
                            "/Users/furkanaydin/Desktop/Inooster/ybi/debug/app-universal-debug.apk");
                    capabilities.AddAdditionalCapability("appium:appPackage","tr.gov.ibb.yurubeistanbul");
                    if (activity != null)
                        capabilities.AddAdditionalCapability("appium:appActivity", "com.yurubeistanbul." + activity);
                    break;
                case Os.iOS:
                    //todo
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(os), os, null);
            }
            return capabilities;
        }
    }
}
