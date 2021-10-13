using System;
using System.Diagnostics;
using AppiumClientMobile.helpers;
using AppiumClientMobile.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.iOS;
using OpenQA.Selenium.Support.UI;
using static AppiumClientMobile.Properties.AccessibilityIds;
using static AppiumClientMobile.Properties.Resources;

namespace AppiumClientMobile.test.iOS
{
    public class StartAppOtpUiViewController
    {
        private IOSDriver<IWebElement> _driver;

        [OneTimeSetUp]
        public void BeforeAll()
        {
            var capabilities = Caps.GetIosXcuiTestCapsWithAppPackage();
            var serverUri = AppiumServers.StartLocalService();
            _driver = new IOSDriver<IWebElement>(serverUri, capabilities, Env.InitTimeOutSec);
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

        
        [Test, Order(0)]
        public void CheckAbilityToEnterNumberView()
        {
            // iOS tarafında ilk açılışta Alerts izinine evet olarak işaretliyoruz!
            _driver.FindElementByAccessibilityId(StartAppOtpUIViewController_Allow).Click();
            
            // Activate
            _driver.FindElementByAccessibilityId(
                OtpPage_SendPhoneNumberToRequiredField_LoginPhoneNumber_).Click();
            _driver
                .FindElementByAccessibilityId(
                    OtpPage_SendPhoneNumberToRequiredField_LoginPhoneNumber_)
                .SendKeys(StartAppOtpActivity_CheckAbilityToEnterNumberScreen_PhoneNumber);
        }
    }
}

