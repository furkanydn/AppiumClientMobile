using AppiumClientMobile.helpers;
using AppiumClientMobile.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;

namespace AppiumClientMobile.test.Motivist.Android.Device
{
    public class LaunchApp
    {
        private AndroidDriver<IWebElement> _driver;

        [OneTimeSetUp]
        public void BeforeAll()
        {
            new DriverWPs(DriverWPs.MobilePlatform.Android, DriverWPs.MobileProject.Motivist, true);
        }

        [SetUp]
        public void SetUp()
        {
            _driver?.LaunchApp();
        }

        [TearDown]
        public void TearDown()
        {
            _driver?.CloseApp();
        }

        [Test]
        public void TestOpenNotifications()
        {
            _driver.OpenNotifications();
        }
    }
}