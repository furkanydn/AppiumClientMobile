using System;
using System.Diagnostics;
using System.Threading;
using AppiumClientMobile.helpers;
using AppiumClientMobile.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using static AppiumClientMobile.Properties.AccessibilityIds;
using static AppiumClientMobile.Properties.Resources;

namespace AppiumClientMobile.test.Motivist.Android.DefaultUserStory
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

        [Test, Order(0)]
        public void CheckAbilityToEnterNumberScreen()
        {
            // LoginPhoneNumber Click
            _driver.FindElementByAccessibilityId(ComMotivistDevelopment_OtpPage_LoginPhoneNumber).Click();
            // LoginPhoneNumber SendKeys
            _driver.FindElementByAccessibilityId(ComMotivistDevelopment_OtpPage_LoginPhoneNumber)
                .SendKeys(ComMotivistDevelopment_CheckAbilityToEnterNumberScreen_EnteredNumber);
            // LoginPhoneNumber Read
            var loginPhoneNumberGetText = _driver
                .FindElementByAccessibilityId(ComMotivistDevelopment_OtpPage_LoginPhoneNumber)
                .Text;
            // LoginPhoneNumber Equal Value Check
            Assert.AreEqual(ComMotivistDevelopment_CheckAbilityToEnterNumberScreen_ExpectedNumber,
                loginPhoneNumberGetText);
            // LoginButton Click
            _driver.FindElementByAccessibilityId(ComMotivistDevelopment_OtpPage_LoginButton).Click();
        }

        [Test, Order(1)]
        public void CheckAbilityToReadOtpCodeFromOtpScreen()
        {
            // OtpTextInput Read
            var dialogMessage = _driver
                .FindElementByAccessibilityId(
                    ComMotivistDevelopment_CheckAbilityToWriteOtpCodeInsideTextArea_DialogTextMessage)
                .Text;
            // OtpTextInput Write Console
            Debug.WriteLine(
                ComMotivistDevelopment_CheckAbilityToGetOtpCodeFromOtpScreenOrGetErrorMessage_ReceivedOtpCodeMessage,
                dialogMessage);
            if (dialogMessage == ComMotivistDevelopment_OtpDialogView_ErrorMessageText)
            {
                Debug.WriteLine(ComMotivistDevelopment_CheckAbilityToGetThreeMinutesError_WaitMessage);
            }
            // OtpDialog Close
            _driver.FindElementByAccessibilityId(
                    ComMotivistDevelopment_CheckFromMessageDialog_DialogNegativeButton)
                .Click();
        }

        [Test, Order(2)]
        public void CheckRenewedOtpCodeReadAndWriteOtpScreen()
        {
            Thread.Sleep(30000);
            // OtpMessageDialog Read
            var dialogTextMessage = _driver
                .FindElementByAccessibilityId(
                    ComMotivistDevelopment_CheckAbilityToWriteOtpCodeInsideTextArea_DialogTextMessage).Text;
            // OtpMessageDialog Equal Value Check
            Assert.AreEqual(ComMotivistDevelopment_OtpDialogView_DialogProcessText,dialogTextMessage);
            // OtpMessageDialog Click Positive
            _driver.FindElementByAccessibilityId(
                    ComMotivistDevelopment_CheckFromMessageDialog_DialogPositiveButton)
                .Click();
            // OtpTextInput Read
            var renewedOtpCode = _driver
                .FindElementByAccessibilityId(
                    ComMotivistDevelopment_CheckAbilityToWriteOtpCodeInsideTextArea_DialogTextMessage)
                .Text;
            // OtpDialog Close
            _driver.FindElementByAccessibilityId(
                    ComMotivistDevelopment_CheckFromMessageDialog_DialogNegativeButton)
                .Click();
            // OtpField Write
            _driver.FindElementByAccessibilityId(
                    ComMotivistDevelopment_CheckAbilityToOtpEnterOtpCodeScreen_OtpEditText)
                .SendKeys(renewedOtpCode);
            // LoginOtpVerify Click
            _driver.FindElementByAccessibilityId(
                    ComMotivistDevelopment_CheckAbilityToOtpEnterOtpCodeScreen_LoginOtpVerify)
                .Click();
        }


        [Test, Order(3)]
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