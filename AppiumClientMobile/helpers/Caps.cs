using AppiumClientMobile.Enums;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Enums;

using static OpenQA.Selenium.Appium.Enums.IOSMobileCapabilityType;
using static OpenQA.Selenium.Appium.Enums.MobileCapabilityType;
using AutomationName = AppiumClientMobile.Enums.AutomationName;

namespace AppiumClientMobile.helpers
{
    public static class Caps
    {
        public static AppiumOptions GetAndroidUiAutomatorCaps(string app)
        {
            var capabilities = new AppiumOptions();
            capabilities.AddAdditionalCapability(MobileCapabilityType.AutomationName, AutomationName.AndroidUiAutomator2);
            capabilities.AddAdditionalCapability(DeviceName, "Android Emulator");
            capabilities.AddAdditionalCapability(App, app);

            return capabilities;
        }
        
        public static AppiumOptions GetAndroidUiAutomatorCapsWithAppPackage()
        {
            var capabilities = new AppiumOptions();

            capabilities.AddAdditionalCapability(App, GeneralDesiredCaps.AppPathAndroid);
            capabilities.AddAdditionalCapability(AndroidMobileCapabilityType.AppPackage, GeneralDesiredCaps.AppPackage);
            capabilities.AddAdditionalCapability(AndroidMobileCapabilityType.AppWaitActivity, GeneralDesiredCaps.AppWaitActivity);

            capabilities.AddAdditionalCapability(PlatformName, GeneralDesiredCaps.PlatformNameAndroid);
            capabilities.AddAdditionalCapability(PlatformVersion, GeneralDesiredCaps.PlatformVersionAndroid);
            capabilities.AddAdditionalCapability(DeviceName, GeneralDesiredCaps.DeviceNameAndroid);
            capabilities.AddAdditionalCapability(Orientation, GeneralDesiredCaps.OrientationPortrait);
            // ReSharper disable once HeapView.BoxingAllocation
            capabilities.AddAdditionalCapability(MobileCapabilityType.NoReset, GeneralDesiredCaps.NoReset);
            // ReSharper disable once HeapView.BoxingAllocation
            capabilities.AddAdditionalCapability(MobileCapabilityType.FullReset, GeneralDesiredCaps.FullReset);

            return capabilities;
        }

        public static AppiumOptions GetIosXcuiTestCaps(string app)
        {
            var capabilities = new AppiumOptions();
            capabilities.AddAdditionalCapability(PlatformName, GeneralDesiredCaps.PlatformNameIos);
            capabilities.AddAdditionalCapability(PlatformVersion, GeneralDesiredCaps.PlatformVersionIos);
            capabilities.AddAdditionalCapability(DeviceName, GeneralDesiredCaps.DeviceNameIos);
            capabilities.AddAdditionalCapability(MobileCapabilityType.AutomationName, AutomationName.XCUITest);
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
            capabilities.AddAdditionalCapability("appium:automationName", "XCUITest");
            capabilities.AddAdditionalCapability("appium:app",GeneralDesiredCaps.AppPathIosMac);
            capabilities.AddAdditionalCapability("appium:wdaBaseUrl",GeneralDesiredCaps.WdaBaseUrl);
            capabilities.AddAdditionalCapability(LaunchTimeout,
                Env.InitTimeOutSec.TotalMilliseconds);

            return capabilities;
        }

        public static AppiumOptions GetAndroidEspressoCaps(string app)
        {
            var capabilities = new AppiumOptions();
            capabilities.AddAdditionalCapability(MobileCapabilityType.AutomationName, AutomationName.AndroidEspresso);
            capabilities.AddAdditionalCapability(DeviceName, "Android Emulator");
            capabilities.AddAdditionalCapability(App, app);

            return capabilities;
        }
    }
}
