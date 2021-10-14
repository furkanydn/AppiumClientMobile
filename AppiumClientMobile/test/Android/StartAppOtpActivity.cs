using AppiumClientMobile.helpers;
using AppiumClientMobile.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using System;
using System.Diagnostics;
using static AppiumClientMobile.Properties.AccessibilityIds;
using static AppiumClientMobile.Properties.Resources;

namespace AppiumClientMobile.test.Android
{
    public class StartAppOtpActivity
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
            string currentActivity = _driver.CurrentActivity;
            Debug.Print(StartAppOtpActivity_CheckAbilityToEnterNumberScreen_Current_Activity__ +
                        currentActivity);
            // Activate
            SendPhoneNumberToRequiredField(StartAppOtpActivity_CheckAbilityToEnterNumberScreen_PhoneNumber);

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
        public void CheckAbilityToGetOtpCodeFromOtpScreenOrGetErrorMessage ()
        {
            if (_driver.FindElementByXPath(
                StartAppOtpActivity_CheckAbilityToGetOtpCodeFromOtpScreenOrGetErrorMessage_OtpTextView).Displayed)
            {
                var otpCode = _driver
                    .FindElementByXPath(
                        StartAppOtpActivity_CheckAbilityToGetOtpCodeFromOtpScreenOrGetErrorMessage_OtpTextView)
                    .Text;
                Debug.WriteLine(
                    StartAppOtpActivity_CheckAbilityToGetOtpCodeFromOtpScreenOrGetErrorMessage_ReceivedOtpCodeMessage,
                    otpCode);
                _driver.FindElementByAccessibilityId(
                        StartAppOtpActivity_CheckAbilityToGetOtpCodeFromOtpScreenOrGetErrorMessage_DialogNegativeButton)
                    .Click();
            }
            else if (_driver
                .FindElementByXPath(
                    StartAppOtpActivity_CheckAbilityToGetOtpCodeFromOtpScreenOrGetErrorMessage_ErrorMessageText)
                .Displayed)
            {
                // If it gets an error before going to the otp screen and the elements there are not visible, it will enter here.
                _driver.FindElementByAccessibilityId(
                        StartAppOtpActivity_CheckAbilityToGetOtpCodeFromOtpScreenOrGetErrorMessage_DialogNegativeButton)
                    .Click();
                Assert.IsTrue(
                    _driver.FindElementByXPath(
                            StartAppOtpActivity_CheckAbilityToGetOtpCodeFromOtpScreenOrGetErrorMessage_ErrorMessageText)
                        .Displayed,
                    StartAppOtpActivity_CheckAbilityToGetThreeMinutesError_Wait_Message__);
            }
            else
            {
                Debug.WriteLine(
                    StartAppOtpActivity_CheckAbilityToGetOtpCodeFromOtpScreenOrGetErrorMessage_UnknownErrorMessage);
            }
        }

        [Test, Order(2)]
        public void CheckAbilityToOtpEnterOtpCodeScreenWithWaitThreeMinAfterOtpRetry()
        {
            SetImplicitWaitTimeoutWithDesiredValueSeconds(5);
            try
            { 
                _driver.FindElementByAccessibilityId(
                        StartAppOtpActivity_CheckAbilityToOtpEnterOtpCodeScreenWithWaitThreeMinAfterOtpRetry_LoginOtpRetryButton)
                    .Click();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            CheckAbilityToEnterNumberScreen();
        }

        [Test, Order(3)]
        public void CheckAbilityToOtpEnterOtpCodeScreen()
        {
            // Get Otp Code And Close Dialog
            string otpCode = _driver
                .FindElementByXPath(
                    StartAppOtpActivity_CheckAbilityToGetOtpCodeFromOtpScreenOrGetErrorMessage_OtpTextView).Text;
            _driver.FindElementByAccessibilityId(
                    StartAppOtpActivity_CheckAbilityToGetOtpCodeFromOtpScreenOrGetErrorMessage_DialogNegativeButton)
                .Click();
            
            // Set Otp Code And Go Main Screen
            _driver.FindElementByXPath(StartAppOtpActivity_CheckAbilityToOtpEnterOtpCodeScreen_OtpEditText)
                .SendKeys(otpCode);

            // If the incoming otp code and the entered otp code are different, the status here is checked.
            Assert.AreEqual(otpCode, _driver.FindElementByXPath(
                StartAppOtpActivity_CheckAbilityToOtpEnterOtpCodeScreen_OtpEditText).Text);

            _driver.FindElementByAccessibilityId(StartAppOtpActivity_CheckAbilityToOtpEnterOtpCodeScreen_LoginOtpVerify)
                .Click();

        }
    }
}