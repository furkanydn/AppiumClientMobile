using AppiumClientMobile.helpers;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;

namespace AppiumClientMobile.test.Motivist.Android.Device
{
    internal class AppTests
    {
        private AppiumDriver<IWebElement> _driver;

        public AppTests(AppiumDriver<IWebElement> driver)
        {
            _driver = driver;
        }

        private const string IntentAppPackageName = "com.motivist.development";

        [OneTimeSetUp]
        public void SetUp()
        {
            new DriverWPs(DriverWPs.MobilePlatform.Android,DriverWPs.MobileProject.Motivist,true);
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