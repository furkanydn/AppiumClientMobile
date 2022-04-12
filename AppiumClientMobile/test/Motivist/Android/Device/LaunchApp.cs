using AppiumClientMobile.helpers;
using AppiumClientMobile.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;

namespace AppiumClientMobile.test.Motivist.Android.Device
{
    public class LaunchApp
    {
        private readonly AndroidDriver<IWebElement> _driver;

        public LaunchApp(AndroidDriver<IWebElement> driver)
        {
            _driver = driver;
        }

        [OneTimeSetUp]
        public void BeforeAll()
        {
            // ReSharper disable once ObjectCreationAsStatement
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