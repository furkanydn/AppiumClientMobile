using System;
using AppiumClientMobile.helpers;
using AppiumClientMobile.Helpers;
using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using static AppiumClientMobile.Properties.AccessibilityIds;
using static AppiumClientMobile.Properties.Resources;

namespace AppiumClientMobile.test.Motivist.Hybrid
{
    public class OtpActivity
    {
        private static AppiumDriver<AppiumWebElement> _driver;

        // ReSharper disable once UnusedMember.Global
        private protected TestContext TestContext { get; set; }

        [OneTimeSetUp]
        public void BeforeAll()
        {
            // If you want to use it for ios use GetAndroidUiAutomatorCapsWithAppPackage or android use default
            var capabilities = Caps.GetAndroidUiAutomatorCapsWithAppPackage();
            var serverUri = AppiumServers.StartLocalService();
            // If you want to use it for ios use iOSDriver or android use AndroidDriver
            _driver = new AndroidDriver<AppiumWebElement>(serverUri, capabilities, Env.InitTimeOutSec);
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
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
            TestContext.WriteLine(ComMotivistDevelopment_Contexts_LoginPhoneNumber + loginPhoneNumberGetText);
            // LoginPhoneNumber Equal Value Check
            Assert.AreEqual(ComMotivistDevelopment_CheckAbilityToEnterNumberScreen_ExpectedNumber,
                loginPhoneNumberGetText);
            TestContext.WriteLine(ComMotivistDevelopment_Contexts_CorrectMessage);
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
            TestContext.WriteLine(ComMotivistDevelopment_Contexts_ReceivedOtpCodeMessage + dialogMessage);
            // If an error message appears instead of the otp code, check
            if (dialogMessage == ComMotivistDevelopment_OtpDialogView_ErrorMessageText)
            {
                TestContext.WriteLine(ComMotivistDevelopment_CheckAbilityToGetThreeMinutesError_WaitMessage);
            }
            // OtpDialog Close
            _driver.FindElementByAccessibilityId(
                    ComMotivistDevelopment_CheckFromMessageDialog_DialogNegativeButton)
                .Click();
            // OtpField Write
            _driver.FindElementByAccessibilityId(
                    ComMotivistDevelopment_CheckAbilityToOtpEnterOtpCodeScreen_OtpEditText)
                .SendKeys(dialogMessage);
            // LoginOtpVerify Click
            _driver.FindElementByAccessibilityId(
                    ComMotivistDevelopment_CheckAbilityToOtpEnterOtpCodeScreen_LoginOtpVerify)
                .Click();
            TestContext.WriteLine(ComMotivistDevelopment_Contexts_CorrectLoginMessage);
        }
    }
}