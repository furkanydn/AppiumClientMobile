using System;
using AppiumClientMobile.helpers;
using AppiumClientMobile.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.iOS;
using static AppiumClientMobile.Properties.AccessibilityIds;

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

        private IWebElement FindAccessId(string accId)
        {
            return _driver.FindElementByAccessibilityId(accId);
        }
        
        [Test, Order(0)]
        public void CheckAbilityToEnterNumberView()
        {
            // iOS tarafında ilk açılışta Alerts izinine evet olarak işaretliyoruz!
            FindAccessId(StartAppOtpUIViewController_Allow).Click();
            
            // Activate
            FindAccessId(ComMotivistDevelopment_OtpPage_LoginPhoneNumber).Click();
            FindAccessId(ComMotivistDevelopment_OtpPage_LoginPhoneNumber)
                .SendKeys(ComMotivistDevelopment_CheckAbilityToEnterNumberScreen_EnteredNumber);
        }
        
        [Test, Order(1)]
        public void CheckAbilityToLoginButtonClick()
        {
            // Activate
            FindAccessId(ComMotivistDevelopment_OtpPage_LoginButton).Click();
        }
    }
}

