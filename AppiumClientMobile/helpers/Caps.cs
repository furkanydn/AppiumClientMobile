using AppiumClientMobile.Enums;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Enums;
using static OpenQA.Selenium.Appium.Enums.IOSMobileCapabilityType;
using static OpenQA.Selenium.Appium.Enums.MobileCapabilityType;
using AutomationName = OpenQA.Selenium.Appium.Enums.AutomationName;

namespace AppiumClientMobile.helpers
{
    public static class Caps
    {
        public static AppiumOptions GetAndroidUiAutomatorCaps(string app)
        {
            var capabilities = new AppiumOptions();
            capabilities.AddAdditionalCapability(MobileCapabilityType.AutomationName, AutomationName.AndroidUIAutomator2);
            capabilities.AddAdditionalCapability(DeviceName, "Android Emulator");
            capabilities.AddAdditionalCapability(App, app);

            return capabilities;
        }
        
        public static AppiumOptions GetAndroidUiAutomatorCapsWithAppPackage()
        {
            var capabilities = new AppiumOptions();

            capabilities.AddAdditionalCapability("appium:app", GeneralDesiredCaps.AppPathAndroidMac);
            capabilities.AddAdditionalCapability("appium:appPackage", GeneralDesiredCaps.AppPackage);
            capabilities.AddAdditionalCapability("appium:appWaitActivity", GeneralDesiredCaps.AppWaitActivity);
            capabilities.AddAdditionalCapability("platformName", GeneralDesiredCaps.PlatformNameAndroid);
            capabilities.AddAdditionalCapability("appium:platformVersion", GeneralDesiredCaps.PlatformVersionAndroid);
            capabilities.AddAdditionalCapability("appium:deviceName", GeneralDesiredCaps.DeviceNameAndroid);
            capabilities.AddAdditionalCapability("appium:automationName",AutomationEngineName.UiAutomator2);
            capabilities.AddAdditionalCapability("appium:orientation", GeneralDesiredCaps.OrientationPortrait);
            // ReSharper disable once HeapView.BoxingAllocation
            capabilities.AddAdditionalCapability("appium:noReset", GeneralDesiredCaps.NoReset);
            // ReSharper disable once HeapView.BoxingAllocation
            capabilities.AddAdditionalCapability("appium:fullReset", GeneralDesiredCaps.FullReset);

            return capabilities;
        }

        public static AppiumOptions GetIosXcuiTestCaps(string app)
        {
            var capabilities = new AppiumOptions();
            capabilities.AddAdditionalCapability(PlatformName, GeneralDesiredCaps.PlatformNameIos);
            capabilities.AddAdditionalCapability(PlatformVersion, GeneralDesiredCaps.PlatformVersionIos);
            capabilities.AddAdditionalCapability(DeviceName, GeneralDesiredCaps.DeviceNameIos);
            capabilities.AddAdditionalCapability(MobileCapabilityType.AutomationName, AutomationEngineName.XcuiTest);
            capabilities.AddAdditionalCapability(App, app);
            capabilities.AddAdditionalCapability(LaunchTimeout,
                Env.InitTimeOutSec.TotalMilliseconds);

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
            capabilities.AddAdditionalCapability(LaunchTimeout,
                Env.InitTimeOutSec.TotalMilliseconds);

            return capabilities;
        }

        public static AppiumOptions GetAndroidEspressoCaps(string app)
        {
            var capabilities = new AppiumOptions();
            capabilities.AddAdditionalCapability(MobileCapabilityType.AutomationName, AutomationEngineName.AndroidEspresso);
            capabilities.AddAdditionalCapability(DeviceName, "Android Emulator");
            capabilities.AddAdditionalCapability(App, app);

            return capabilities;
        }
    }
}
