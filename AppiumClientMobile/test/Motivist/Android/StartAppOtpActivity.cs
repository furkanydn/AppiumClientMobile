using System;
using System.Diagnostics;
using AppiumClientMobile.helpers;
using AppiumClientMobile.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using static AppiumClientMobile.Properties.AccessibilityIds;
using static AppiumClientMobile.Properties.Resources;

namespace AppiumClientMobile.test.Motivist.Android
{
    public class StartAppOtpActivity
    {
        private static AndroidDriver<IWebElement> _driver;

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

        // Methods
        private static void SendPhoneNumberToRequiredField(string number)
        {
            _driver.FindElementByAccessibilityId(ComMotivistDevelopment_OtpPage_LoginPhoneNumber)
                .Click();
            _driver.FindElementByAccessibilityId(ComMotivistDevelopment_OtpPage_LoginPhoneNumber)
                .SendKeys(number);
        }

        private static void SetImplicitWaitTimeoutWithDesiredValueSeconds(double waitTime)
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(waitTime);
        }

        [Test, Order(0)]
        public void CheckAbilityToEnterNumberScreen()
        {
            var currentActivity = _driver.CurrentActivity;
            TestContext.WriteLine(StartAppOtpActivity_CheckAbilityToEnterNumberScreen_Current_Activity__ +
                        currentActivity);
            // Activate
            SendPhoneNumberToRequiredField(ComMotivistDevelopment_CheckAbilityToEnterNumberScreen_EnteredNumber);

            // Verify
            var loginPhoneNumberGetText = _driver
                .FindElementByAccessibilityId(ComMotivistDevelopment_OtpPage_LoginPhoneNumber)
                .Text;
            Assert.AreEqual(ComMotivistDevelopment_CheckAbilityToEnterNumberScreen_ExpectedNumber,
                loginPhoneNumberGetText);

            // Login Button Click
            _driver.FindElementByAccessibilityId(ComMotivistDevelopment_OtpPage_LoginButton).Click();
        }

        [Test, Order(1)]
        public void CheckAbilityToGetOtpCodeFromOtpScreenOrGetErrorMessage ()
        {
            if (_driver.FindElementByXPath(
                ComMotivistDevelopment_CheckAbilityToWriteOtpCodeInsideTextArea_DialogTextMessage).Displayed)
            {
                var otpCode = _driver
                    .FindElementByXPath(
                        ComMotivistDevelopment_CheckAbilityToWriteOtpCodeInsideTextArea_DialogTextMessage)
                    .Text;
                Debug.WriteLine(
                    ComMotivistDevelopment_Contexts_ReceivedOtpCodeMessage,
                    otpCode);
                _driver.FindElementByAccessibilityId(
                        ComMotivistDevelopment_CheckFromMessageDialog_DialogNegativeButton)
                    .Click();
            }
            else if (_driver
                .FindElementByXPath(
                    ComMotivistDevelopment_OtpDialogView_ErrorMessageText)
                .Displayed)
            {
                // If it gets an error before going to the otp screen and the elements there are not visible, it will enter here.
                _driver.FindElementByAccessibilityId(
                        ComMotivistDevelopment_CheckFromMessageDialog_DialogNegativeButton)
                    .Click();
                Assert.IsTrue(
                    _driver.FindElementByXPath(
                            ComMotivistDevelopment_OtpDialogView_ErrorMessageText)
                        .Displayed,
                    ComMotivistDevelopment_CheckAbilityToGetThreeMinutesError_WaitMessage);
            }
            else
            {
                Debug.WriteLine(
                    ComMotivistDevelopment_Messages_UnknownErrorMessage);
            }
        }

        [Test, Order(2)]
        public void CheckAbilityToOtpEnterOtpCodeScreenWithWaitThreeMinAfterOtpRetry()
        {
            SetImplicitWaitTimeoutWithDesiredValueSeconds(5);
            try
            { 
                _driver.FindElementByAccessibilityId(
                        ComMotivistDevelopment_CheckAbilityToOtpEnterOtpCodeScreenWithWaitThreeMinAfterOtpRetry_LoginOtpRetryButton)
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
                    ComMotivistDevelopment_CheckAbilityToWriteOtpCodeInsideTextArea_DialogTextMessage).Text;
            _driver.FindElementByAccessibilityId(
                    ComMotivistDevelopment_CheckFromMessageDialog_DialogNegativeButton)
                .Click();
            
            // Set Otp Code And Go Main Screen
            _driver.FindElementByXPath(ComMotivistDevelopment_CheckAbilityToOtpEnterOtpCodeScreen_OtpEditText)
                .SendKeys(otpCode);

            // If the incoming otp code and the entered otp code are different, the status here is checked.
            Assert.AreEqual(otpCode, _driver.FindElementByXPath(
                ComMotivistDevelopment_CheckAbilityToOtpEnterOtpCodeScreen_OtpEditText).Text);

            _driver.FindElementByAccessibilityId(ComMotivistDevelopment_CheckAbilityToOtpEnterOtpCodeScreen_LoginOtpVerify)
                .Click();

        }
    }
}