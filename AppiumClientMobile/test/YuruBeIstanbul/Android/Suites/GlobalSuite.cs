using System;
using AppiumClientMobile.helpers;
using AppiumClientMobile.Helpers;
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
            new DriverWPs(DriverWPs.MobilePlatform.Android, DriverWPs.MobileProject.Ybi, true);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown() => AppiumServers.StopLocalService();

        [Test]
        [Order(0)]
        public static void Walkthrough() => Suites.Walkthrough.CheckWalkthroughScreenComponents(Driver);

        [Test]
        [Order(1)]
        public static void Register() => Suites.Register.CheckRegisterScreenComponents(Driver);
    }
}