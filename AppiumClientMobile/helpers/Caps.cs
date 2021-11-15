using AppiumClientMobile.Enums;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Enums;

namespace AppiumClientMobile.helpers
{
    public static class Caps
    {
        // This capabilities method will only be used for connection checks.
        public static AppiumOptions GetAndroidUiAutomatorCaps(string appPath)
        {
            var capabilities = new AppiumOptions();
            
            capabilities.AddAdditionalCapability(MobileCapabilityType.PlatformName, GeneralDesiredCaps.PlatformNameAndroid);
            capabilities.AddAdditionalCapability(MobileCapabilityType.PlatformVersion, GeneralDesiredCaps.PlatformVersionAndroid);
            capabilities.AddAdditionalCapability(MobileCapabilityType.DeviceName,  "Android Emulator 5554"); 
            capabilities.AddAdditionalCapability(MobileCapabilityType.AutomationName, AutomationEngineName.UiAutomator2);
            capabilities.AddAdditionalCapability(MobileCapabilityType.App, appPath);
            
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

        public static AppiumOptions GetIosXcuiTestCaps(string app)
        {
            var capabilities = new AppiumOptions();
            capabilities.AddAdditionalCapability(MobileCapabilityType.PlatformName, GeneralDesiredCaps.PlatformNameIos);
            capabilities.AddAdditionalCapability(MobileCapabilityType.PlatformVersion, GeneralDesiredCaps.PlatformVersionIos);
            capabilities.AddAdditionalCapability(MobileCapabilityType.DeviceName, GeneralDesiredCaps.DeviceNameIos);
            capabilities.AddAdditionalCapability(MobileCapabilityType.AutomationName, AutomationEngineName.XcuiTest);
            capabilities.AddAdditionalCapability(MobileCapabilityType.App, app);

            return capabilities;
        }
        
        public static AppiumOptions GetIosXcuiTestCapsWithAppPackage()
        {
            var capabilities = new AppiumOptions();
            capabilities.AddAdditionalCapability("platformName", GeneralDesiredCaps.PlatformNameIos);
            capabilities.AddAdditionalCapability("appium:platformVersion", GeneralDesiredCaps.PlatformVersionIos);
            capabilities.AddAdditionalCapability("appium:deviceName", GeneralDesiredCaps.DeviceNameIos);
            capabilities.AddAdditionalCapability("appium:automationName", AutomationEngineName.XcuiTest);
            capabilities.AddAdditionalCapability("appium:app",GeneralDesiredCaps.AppPathIosMac);
            capabilities.AddAdditionalCapability("appium:wdaBaseUrl",GeneralDesiredCaps.WdaBaseUrl);
            capabilities.AddAdditionalCapability("noReset",GeneralDesiredCaps.NoReset);
            capabilities.AddAdditionalCapability("bundleId",GeneralDesiredCaps.BundleId);

            return capabilities;
        }
    }
}
