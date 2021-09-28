using AppiumClientMobile.helpers;
using AppiumClientMobile.Helpers;
using AppiumClientMobile.Properties;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using System;
using System.Diagnostics;
using System.Threading;

namespace AppiumClientMobile.test.Android
{
    public class StartAppOtpActivity
    {
        static AndroidDriver<IWebElement> _driver;

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
            _driver.FindElementByAccessibilityId("login_phone_number").Click();
            _driver.FindElementByAccessibilityId("login_phone_number").SendKeys(number);
        }

        private void SetImplicitWaitTimeoutWithDesiredValueSeconds(int number)
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(number);
        }

        [Test, Order(0)]
        public void CheckAbilityToEnterNumberScreen()
        {
            string currentActivity = _driver.CurrentActivity;
            Debug.Print(Resources.StartAppOtpActivity_CheckAbilityToEnterNumberScreen_Current_Activity__ +
                        currentActivity);
            // Activate
            SendPhoneNumberToRequiredField("5551234567");

            // Verify
            var loginPhoneNumberGetText = _driver.FindElementByAccessibilityId("login_phone_number").Text;
            Assert.AreEqual("(555) 123 45 67", loginPhoneNumberGetText);

            // Login Button Click
            _driver.FindElementByAccessibilityId("login_button").Click();
        }

        [Test, Order(1)]
        public void CheckAbilityToGetOtpCodeFromOtpScreenOrGetErrorMessage ()
        {
            if (_driver.FindElementByXPath("//android.view.ViewGroup[1]/android.widget.TextView[2]").Displayed)
            {
                var otpCode = _driver.FindElementByXPath("//android.view.ViewGroup[1]/android.widget.TextView[2]")
                    .Text;
                Debug.WriteLine("Received OTP Code: ", otpCode);
                _driver.FindElementByAccessibilityId("dialog_negative_button").Click();
            }
            else if (_driver.FindElementByXPath("//*[@text=\"Bir hata ile karşılaşıldı.\"]").Displayed)
            {
                // If it gets an error before going to the otp screen and the elements there are not visible, it will enter here.
                _driver.FindElementByAccessibilityId("dialog_negative_button").Click();
                Assert.IsTrue(_driver.FindElementByXPath("//*[@text=\"Bir hata ile karşılaşıldı.\"]").Displayed,
                    Resources.StartAppOtpActivity_CheckAbilityToGetThreeMinutesError_Wait_Message__);
            }
            else
            {
                Debug.WriteLine("An unknown error has occurred please contact the Inooster !");
            }
        }

        [Test, Order(2)]
        public void CheckAbilityToOtpEnterOtpCodeScreenWithWaitThreeMinAfterOtpRetry()
        {
            SetImplicitWaitTimeoutWithDesiredValueSeconds(5);
            _driver.FindElementByAccessibilityId("login_otp_retry").Click();
            Thread.Sleep(3 * 60 * 1000); // Wait 3 Minute For Re-Otp
            CheckAbilityToEnterNumberScreen();
        }

        [Test, Order(3)]
        public void CheckAbilityToOtpEnterOtpCodeScreen()
        {
            // Get Otp Code And Close Dialog
            string otpCode = _driver.FindElementByXPath("//android.view.ViewGroup[1]/android.widget.TextView[2]").Text;
            _driver.FindElementByAccessibilityId("dialog_negative_button").Click();
            
            // Set Otp Code And Go Main Screen
            _driver.FindElementByXPath(
                "//android.view.ViewGroup[7]/android.view.ViewGroup/android.view.ViewGroup/android.widget.EditText").SendKeys(otpCode);

            // If the incoming otp code and the entered otp code are different, the status here is checked.
            Assert.AreEqual(otpCode, _driver.FindElementByXPath(
                "//android.view.ViewGroup[7]/android.view.ViewGroup/android.view.ViewGroup/android.widget.EditText").Text);

            _driver.FindElementByAccessibilityId("login_otp_verify").Click();
        }
    }
}