using AppiumClientMobile.Enums;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Enums;
using static AppiumClientMobile.Enums.GeneralDesiredCaps;
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

            capabilities.AddAdditionalCapability(App, AppPathAndroid);
            capabilities.AddAdditionalCapability(AndroidMobileCapabilityType.AppPackage, GeneralDesiredCaps.AppPackage);
            capabilities.AddAdditionalCapability(AndroidMobileCapabilityType.AppWaitActivity, GeneralDesiredCaps.AppWaitActivity);

            capabilities.AddAdditionalCapability(PlatformName, PlatformNameAndroid);
            capabilities.AddAdditionalCapability(PlatformVersion, PlatformVersionAndroid);
            capabilities.AddAdditionalCapability(DeviceName, DeviceNameAndroid);
            capabilities.AddAdditionalCapability(Orientation, OrientationPortrait);
            // ReSharper disable once HeapView.BoxingAllocation
            capabilities.AddAdditionalCapability(MobileCapabilityType.NoReset, GeneralDesiredCaps.NoReset);
            // ReSharper disable once HeapView.BoxingAllocation
            capabilities.AddAdditionalCapability(MobileCapabilityType.FullReset, GeneralDesiredCaps.FullReset);

            return capabilities;
        }

        public static AppiumOptions GetIosXcuiTestCaps(string app)
        {
            var capabilities = new AppiumOptions();
            capabilities.AddAdditionalCapability(PlatformName, PlatformNameIos);
            capabilities.AddAdditionalCapability(PlatformVersion, PlatformVersionIos);
            capabilities.AddAdditionalCapability(DeviceName, DeviceNameIos);
            capabilities.AddAdditionalCapability(MobileCapabilityType.AutomationName, AutomationName.XCUITest);
            capabilities.AddAdditionalCapability(App, app);
            capabilities.AddAdditionalCapability(IOSMobileCapabilityType.LaunchTimeout,
                Env.InitTimeOutSec.TotalMilliseconds);

            return capabilities;
        }
        
        public static AppiumOptions GetIosXcuiTestCapsWithAppPackage()
        {
            var capabilities = new AppiumOptions();
            capabilities.AddAdditionalCapability(PlatformName, PlatformNameIos);
            capabilities.AddAdditionalCapability(PlatformVersion, PlatformVersionIos);
            capabilities.AddAdditionalCapability(DeviceName, DeviceNameIos);
            capabilities.AddAdditionalCapability(MobileCapabilityType.AutomationName, AutomationName.XCUITest);
            capabilities.AddAdditionalCapability(App,AppPathIosMac);
            capabilities.AddAdditionalCapability(Orientation, OrientationPortrait);
            capabilities.AddAdditionalCapability(IOSMobileCapabilityType.LaunchTimeout,
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
