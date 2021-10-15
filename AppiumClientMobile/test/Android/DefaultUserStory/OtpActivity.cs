using System;
using System.Diagnostics;
using AppiumClientMobile.helpers;
using AppiumClientMobile.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using static AppiumClientMobile.Properties.AccessibilityIds;
using static AppiumClientMobile.Properties.Resources;

namespace AppiumClientMobile.test.Android.DefaultUserStory
{
    public class OtpActivity
    {
        private static AndroidDriver<IWebElement> _driver;

        [OneTimeSetUp]
        public void BeforeAll()
        {
            var capabilities = Caps.GetAndroidUiAutomatorCapsWithAppPackage();
            var serverUri = AppiumServers.StartLocalService();
            _driver = new AndroidDriver<IWebElement>(serverUri, capabilities, Env.InitTimeOutSec);
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

        // Methods
        private static void SendPhoneNumberToRequiredField(string number)
        {
            _driver.FindElementByAccessibilityId(OtpPage_SendPhoneNumberToRequiredField_LoginPhoneNumber_)
                .Click();
            _driver.FindElementByAccessibilityId(OtpPage_SendPhoneNumberToRequiredField_LoginPhoneNumber_)
                .SendKeys(number);
        }
        
        private void SetImplicitWaitTimeoutWithDesiredValueSeconds(double waitTime)
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(waitTime);
        }

        [Test, Order(0)]
        public void CheckAbilityToEnterNumberScreen()
        {
            // Activate
            SendPhoneNumberToRequiredField(ComMotivistDevelopment_CheckNumberEntryFeatureOnTheNumberEntryScreen_LoginPhoneNumber);
            // Verify
            var loginPhoneNumberGetText = _driver
                .FindElementByAccessibilityId(OtpPage_SendPhoneNumberToRequiredField_LoginPhoneNumber_)
                .Text;
            Assert.AreEqual(StartAppOtpActivity_CheckAbilityToEnterNumberScreen_ExpectedNumber,
                loginPhoneNumberGetText);

            // Login Button Click
            _driver.FindElementByAccessibilityId(OtpPage_CheckAbilityToEnterNumberScreen_LoginButton).Click();
        }
        
        [Test, Order(1)]
        public void CheckAbilityToReadAndWriteOtpCodeFromOtpScreen()
        {
            var otpCode = _driver
                .FindElementByXPath(
                    Android_ComMotivistDevelopment_CheckAbilityToWriteOtpCodeInsideTextArea_OtpTextArea)
                .Text;
            Debug.WriteLine(
                StartAppOtpActivity_CheckAbilityToGetOtpCodeFromOtpScreenOrGetErrorMessage_ReceivedOtpCodeMessage,
                otpCode);
            _driver.FindElementByAccessibilityId(
                    ComMotivistDevelopment_CheckFromMessageDialog_DialogNegativeButton)
                .Click();
            _driver.FindElementByXPath(StartAppOtpActivity_CheckAbilityToOtpEnterOtpCodeScreen_OtpEditText)
                .SendKeys(otpCode);
            
            _driver.FindElementByAccessibilityId(StartAppOtpActivity_CheckAbilityToOtpEnterOtpCodeScreen_LoginOtpVerify)
                .Click();
        }

        [Test, Order(2)]
        public void CheckAbilityToClickOnMainViewBottomBarButton()
        {
            // Add Wait Timer
            
            _driver.FindElementById(
                ComMotivistDevelopment_CheckAbilityToClickOnMainViewBottomBarButton_NavigationMainMissions).Click();
            _driver.FindElementById(
                ComMotivistDevelopment_CheckAbilityToClickOnMainViewBottomBarButton_NavigationMainBusinessGoals)
                .Click();
            _driver.FindElementById(
                ComMotivistDevelopment_CheckAbilityToClickOnMainViewBottomBarButton_NavigationMainIndex).Click();
            _driver.FindElementById(
                ComMotivistDevelopment_CheckAbilityToClickOnMainViewBottomBarButton_NavigationMainMarket).Click();
            _driver.FindElementById(
                ComMotivistDevelopment_CheckAbilityToClickOnMainViewBottomBarButton_NavigationMainNewsfeeds).Click();
            
        }
    }
}