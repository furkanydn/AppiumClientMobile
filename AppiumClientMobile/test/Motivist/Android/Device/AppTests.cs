using System;
using AppiumClientMobile.helpers;
using AppiumClientMobile.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;

namespace AppiumClientMobile.test.Motivist.Android.Device
{
    internal class AppTests
    {
        private AppiumDriver<IWebElement> _driver;
        private const string IntentAppPackageName = "com.motivist.development";

        [OneTimeSetUp]
        public void SetUp()
        {
            var capabilities = Caps.GetAndroidUiAutomatorCapsWithAppPackage();
            var serverUri = AppiumServers.StartLocalService();
            _driver = new AndroidDriver<IWebElement>(serverUri, capabilities, Env.InitTimeOutSec);
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            _driver.Dispose();
        }

        #region Activate App

        [Test]
        public void CanActivateAppTest()
        {
            // Activate
            Assert.DoesNotThrow(() => _driver.ActivateApp(IntentAppPackageName));
            // Verify

            // To Do
        }
        
        #endregion
    }
}