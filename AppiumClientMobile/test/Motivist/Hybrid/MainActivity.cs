using System;
using AppiumClientMobile.helpers;
using AppiumClientMobile.Helpers;
using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using static AppiumClientMobile.Properties.AccessibilityIds;

namespace AppiumClientMobile.test.Motivist.Hybrid
{
    [TestFixture, Order(1)]
    public class MainActivity
    {
        private AppiumDriver<AppiumWebElement> _driver;
        private AppiumOptions _appiumOptions;
        // Resharper disable once UnusedMember.Global
        private protected TestContext TestContext { get; set; }

        [OneTimeSetUp]
        public void BeforeAll()
        {
            // If you want to use it for ios use GetAndroidUiAutomatorCapsWithAppPackage or android use default
            _appiumOptions = Caps.GetAndroidUiAutomatorCaps();
            var serverUri = AppiumServers.StartLocalService();
            // If you want to use it for ios use iOSDriver or android use AndroidDriver
            _driver = new AndroidDriver<AppiumWebElement>(serverUri, _appiumOptions, Env.InitTimeOutSec);
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
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
        public void CheckAbilityToClickOnMainViewBottomBarButton()
        {
            _driver.FindElementById(
                    ComMotivistDevelopment_CheckAbilityToClickOnMainViewBottomBarButton_NavigationMainMissions)
                .Click();
            _driver.FindElementById(
                    ComMotivistDevelopment_CheckAbilityToClickOnMainViewBottomBarButton_NavigationMainBusinessGoals)
                .Click();
            _driver.FindElementById(
                    ComMotivistDevelopment_CheckAbilityToClickOnMainViewBottomBarButton_NavigationMainIndex)
                .Click();
            _driver.FindElementById(
                    ComMotivistDevelopment_CheckAbilityToClickOnMainViewBottomBarButton_NavigationMainMarket)
                .Click();
            _driver.FindElementById(
                    ComMotivistDevelopment_CheckAbilityToClickOnMainViewBottomBarButton_NavigationMainNewsfeeds)
                .Click();
        }
    }
}