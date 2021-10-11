using NUnit.Framework;
using System;
using AppiumClientMobile.helpers;
using AppiumClientMobile.Helpers;
using AppiumClientMobile.Properties;
using OpenQA.Selenium.Appium.iOS;
using static AppiumClientMobile.helpers.Caps;

namespace AppiumClientMobile.test.iOS.Device
{
    public class CheckAbilityToIsAppInstalled
    {
        private IOSDriver<IOSElement> _driver;

        [OneTimeSetUp]
        public void BeforeAll()
        {
            var capabilities = GetIosXcuiTestCapsWithAppPackage();
            var serverUri = AppiumServers.StartLocalService();
            _driver = new IOSDriver<IOSElement>(serverUri, capabilities, Env.InitTimeOutSec);
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            _driver.LaunchApp();
        }

        [SetUp]
        public void SetUp()
        {
            //If we want the application to load in every test case, remove the comment line here.
            //_driver?.LaunchApp();
        }

        [TearDown]
        public void TearDown()
        {
            //If we want the application to be closed in every test case, remove the comment line here.
            //_driver.CloseApp(); 
            //_driver.ResetApp();
        }

        [Test]
        public void CheckIfAppIsInstalledOnSimulator()
        {
            Boolean isInstalled = _driver.IsAppInstalled("com.Motivist.Dev");
            Assert.IsTrue(condition: isInstalled, message: Resources.CheckIfAppInstalled_IsInstalledMessage__);
        }
    }
}
