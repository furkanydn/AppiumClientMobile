using AppiumClientMobile.Enums;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Enums;

namespace AppiumClientMobile.helpers
{
    public static class Caps
    {
        // This capabilities method will only be used for connection checks.
        public static AppiumOptions GetAndroidUiAutomatorCaps()
        {
            var capabilities = new AppiumOptions();
            
            capabilities.AddAdditionalCapability("platformName", MobilePlatform.Android);
            capabilities.AddAdditionalCapability("appium:platformVersion", GeneralDesiredCaps.PlatformVersionAndroid);
            capabilities.AddAdditionalCapability("appium:deviceName", GeneralDesiredCaps.DeviceNameAndroid);
            capabilities.AddAdditionalCapability("appium:automationName",AutomationEngineName.UiAutomator2);
            capabilities.AddAdditionalCapability("appPackage", GeneralDesiredCaps.AppPackage);
            capabilities.AddAdditionalCapability("appWaitActivity", GeneralDesiredCaps.AppWaitActivity);
            capabilities.AddAdditionalCapability("orientation", GeneralDesiredCaps.OrientationPortrait);
            capabilities.AddAdditionalCapability("noReset", GeneralDesiredCaps.NoReset);
            capabilities.AddAdditionalCapability("fullReset", GeneralDesiredCaps.FullReset);
            
            return capabilities;
        }
        
        public static AppiumOptions GetAndroidUiAutomatorCapsWithAppPackage()
        {
            var capabilities = new AppiumOptions();
            capabilities.AddAdditionalCapability("platformName", MobilePlatform.Android);
            capabilities.AddAdditionalCapability("appium:platformVersion", GeneralDesiredCaps.PlatformVersionAndroid);
            capabilities.AddAdditionalCapability("appium:deviceName", GeneralDesiredCaps.DeviceNameAndroid);
            capabilities.AddAdditionalCapability("appium:automationName",AutomationEngineName.UiAutomator2);
            capabilities.AddAdditionalCapability("appium:app",GeneralDesiredCaps.AppPathAndroidMac);
            capabilities.AddAdditionalCapability("appPackage", GeneralDesiredCaps.AppPackage);
            capabilities.AddAdditionalCapability("appWaitActivity", GeneralDesiredCaps.AppWaitActivity);
            capabilities.AddAdditionalCapability("orientation", GeneralDesiredCaps.OrientationPortrait);
            capabilities.AddAdditionalCapability("noReset", GeneralDesiredCaps.NoReset);
            capabilities.AddAdditionalCapability("fullReset", GeneralDesiredCaps.FullReset);

            return capabilities;
        }

        public static AppiumOptions GetIosXcuiTestCaps()
        {
            // ReSharper disable once SuggestVarOrType_SimpleTypes
            AppiumOptions capabilities = new AppiumOptions();
            capabilities.AddAdditionalCapability("platformName", MobilePlatform.IOS);
            capabilities.AddAdditionalCapability("appium:platformVersion", GeneralDesiredCaps.PlatformVersionIos);
            capabilities.AddAdditionalCapability("appium:deviceName", GeneralDesiredCaps.DeviceNameIos);
            capabilities.AddAdditionalCapability("appium:automationName", AutomationEngineName.XcuiTest);
            capabilities.AddAdditionalCapability("appium:wdaBaseUrl",GeneralDesiredCaps.WdaBaseUrl);
            capabilities.AddAdditionalCapability("noReset",GeneralDesiredCaps.NoReset);
            capabilities.AddAdditionalCapability("bundleId",GeneralDesiredCaps.BundleId);

            return capabilities;
        }
        
        public static AppiumOptions GetIosXcuiTestCapsWithAppPackage()
        {
            // ReSharper disable once SuggestVarOrType_SimpleTypes
            AppiumOptions capabilities = new AppiumOptions();
            capabilities.AddAdditionalCapability("platformName", MobilePlatform.IOS);
            capabilities.AddAdditionalCapability("appium:platformVersion", GeneralDesiredCaps.PlatformVersionIos);
            capabilities.AddAdditionalCapability("appium:deviceName", GeneralDesiredCaps.DeviceNameIos);
            capabilities.AddAdditionalCapability("appium:automationName", AutomationEngineName.XcuiTest);
            capabilities.AddAdditionalCapability("appium:app",GeneralDesiredCaps.AppPathIosMac);
            capabilities.AddAdditionalCapability("appium:wdaBaseUrl",GeneralDesiredCaps.WdaBaseUrl);
            capabilities.AddAdditionalCapability("noReset",GeneralDesiredCaps.NoReset);
            capabilities.AddAdditionalCapability("bundleId",GeneralDesiredCaps.BundleId);

            return capabilities;
        }
        
        public static AppiumOptions GetAndroidYuruBeIstanbulCapabilities()
        {
            var capabilities = new AppiumOptions();
            capabilities.AddAdditionalCapability("platformName", MobilePlatform.Android);
            capabilities.AddAdditionalCapability("appium:platformVersion", "11");
            capabilities.AddAdditionalCapability("appium:deviceName", "Pixel3s");
            capabilities.AddAdditionalCapability("appium:automationName","UIAutomator2");
            capabilities.AddAdditionalCapability("appium:app","/Users/furkanaydin/Desktop/Inooster/ybi/debug/app-universal-debug.apk");
            capabilities.AddAdditionalCapability("noReset", true);
            capabilities.AddAdditionalCapability("fullReset", false);
            return capabilities;
        }
    }
}
