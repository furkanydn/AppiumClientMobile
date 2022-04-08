using System;
using AppiumClientMobile.helpers;
using AppiumClientMobile.Helpers;
using AppiumClientMobile.test.YuruBeIstanbul.Android.Objects.Constant;
using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;

namespace AppiumClientMobile.test.YuruBeIstanbul.Android.Suites
{
    [TestFixture]
    [NonParallelizable]
    [Description("Opened in order to keep track of all test classes in one place.")]
    public class GlobalSuite
    {
        // ReSharper disable once MemberCanBePrivate.Global
        public static AppiumDriver<AppiumWebElement> Driver { get; set; }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            var caps = Caps.GetAndroidYuruBeIstanbulCapabilities();
            var server = AppiumServers.StartLocalService();
            Driver = new AndroidDriver<AppiumWebElement>(server, caps, Env.InitTimeOutSec);
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(45);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown() => AppiumServers.StopLocalService();

        [Test]
        [Order(0)]
        public static void Walkthrough() => Suites.Walkthrough.CheckWalkthroughScreenComponents(Driver);
    }
}