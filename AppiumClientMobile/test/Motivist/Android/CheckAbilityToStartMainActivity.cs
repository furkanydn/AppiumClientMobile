using System;
using AppiumClientMobile.helpers;
using AppiumClientMobile.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;

namespace AppiumClientMobile.test.Motivist.Android
{
    public class CheckAbilityToStartMainActivity
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

        [Test, Order(0)]
        public void CheckAbilityToStartMainActivityTabs()
        {
            // b8bbc5ef-d093-4338-6022-08d97e766bad
        }
    }
}