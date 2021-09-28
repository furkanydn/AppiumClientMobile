﻿using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using AppiumClientMobile.Enums;
using AppiumClientMobile.Properties;
using AutomationName = OpenQA.Selenium.Appium.Enums.AutomationName;

namespace AppiumClientMobile.helpers
{
    public class Caps
    {
        public static AppiumOptions GetAndroidUiAutomatorCaps(string app)
        {
            var capabilities = new AppiumOptions();
            capabilities.AddAdditionalCapability(MobileCapabilityType.AutomationName, AutomationName.AndroidUIAutomator2);
            capabilities.AddAdditionalCapability(MobileCapabilityType.DeviceName, "Android Emulator");
            capabilities.AddAdditionalCapability(MobileCapabilityType.App, app);

            return capabilities;
        }
        
        public static AppiumOptions GetAndroidUiAutomatorCapsWithAppPackage()
        {
            var capabilities = new AppiumOptions();

            capabilities.AddAdditionalCapability(MobileCapabilityType.App, GeneralDesiredCaps.AppPathAndroid);
            capabilities.AddAdditionalCapability(AndroidMobileCapabilityType.AppPackage, GeneralDesiredCaps.AppPackage);
            capabilities.AddAdditionalCapability(AndroidMobileCapabilityType.AppWaitActivity, GeneralDesiredCaps.AppWaitActivity);

            capabilities.AddAdditionalCapability(MobileCapabilityType.PlatformName, GeneralDesiredCaps.PlatformNameAndroid);
            capabilities.AddAdditionalCapability(MobileCapabilityType.PlatformVersion, GeneralDesiredCaps.PlatformVersionAndroid);
            capabilities.AddAdditionalCapability(MobileCapabilityType.DeviceName, GeneralDesiredCaps.DeviceNameAndroid);
            capabilities.AddAdditionalCapability(MobileCapabilityType.Orientation, GeneralDesiredCaps.OrientationPortrait);
            // ReSharper disable once HeapView.BoxingAllocation
            capabilities.AddAdditionalCapability(MobileCapabilityType.NoReset, GeneralDesiredCaps.NoReset);
            // ReSharper disable once HeapView.BoxingAllocation
            capabilities.AddAdditionalCapability(MobileCapabilityType.FullReset, GeneralDesiredCaps.FullReset);

            return capabilities;
        }

        public static AppiumOptions GetIosCaps(string app)
        {
            var capabilities = new AppiumOptions();
            capabilities.AddAdditionalCapability(MobileCapabilityType.AutomationName, AutomationName.iOSXcuiTest);
            capabilities.AddAdditionalCapability(MobileCapabilityType.DeviceName, "iPhone X");
            capabilities.AddAdditionalCapability(MobileCapabilityType.PlatformVersion, "12.0");
            capabilities.AddAdditionalCapability(MobileCapabilityType.App, app);
            capabilities.AddAdditionalCapability(IOSMobileCapabilityType.LaunchTimeout, Env.InitTimeOutSec.TotalMilliseconds);

            return capabilities;
        }

        public static AppiumOptions GetAndroidEspressoCaps(string app)
        {
            var capabilities = new AppiumOptions();
            capabilities.AddAdditionalCapability(MobileCapabilityType.AutomationName, AutomationName.AndroidEspresso);
            capabilities.AddAdditionalCapability(MobileCapabilityType.DeviceName, "Android Emulator");
            capabilities.AddAdditionalCapability(MobileCapabilityType.App, app);

            return capabilities;
        }
    }
}
