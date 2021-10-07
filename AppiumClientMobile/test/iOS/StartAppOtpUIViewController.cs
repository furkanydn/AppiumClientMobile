using System;
using AppiumClientMobile.helpers;
using AppiumClientMobile.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.iOS;

namespace AppiumClientMobile.test.iOS
{
    public class StartAppOtpUIViewController
    {
        public IOSDriver<IWebElement> _driver;

        [OneTimeSetUp]
        public void BeforeAll()
        {
            var capabilities = Caps.GetAndroidUiAutomatorCapsWithAppPackage();
            var serverUri = AppiumServers.StartLocalService();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            _driver.LaunchApp();
        }


        public StartAppOtpUIViewController()
        {
            
        }
    }
}

