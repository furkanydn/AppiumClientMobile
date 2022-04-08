using AppiumClientMobile.test.YuruBeIstanbul.Android.Objects.Components;
using AppiumClientMobile.test.YuruBeIstanbul.Android.Objects.Constant;
using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.MultiTouch;

namespace AppiumClientMobile.test.YuruBeIstanbul.Android.Suites
{
    [TestFixture]
    public class Register
    {
        [Test]
        [Order(0)]
        public static void CheckRegisterScreenComponents([Values(typeof(AppiumDriver<AppiumWebElement>))] AppiumDriver<AppiumWebElement> appiumDriver)
        {
            //todo Add Two Assert
            appiumDriver.FindElementById(RegisterComponent.TcRegisterNameSurnameInput)
                .SendKeys(RegisterConst.TcRegisterNameSurnameInputValid);
            appiumDriver.FindElementById(RegisterComponent.TcRegisterGenderInput).Click();
            appiumDriver.FindElementById(RegisterComponent.TcRegisterGenderUnknown).Click();
            appiumDriver.FindElementById(RegisterComponent.TcRegisterPositiveButton).Click();
            appiumDriver.FindElementById(RegisterComponent.TcRegisterBirthday).Click();
            for (var i = 0; i < 4; i++)
                new TouchAction(appiumDriver).Press(750, 1525).MoveTo(750, 1850).Release().Perform();
            for (var i = 0; i < 5; i++)
                new TouchAction(appiumDriver).Press(525, 1525).MoveTo(525, 1850).Release().Perform();
            for (var i = 0; i < 6; i++)
                new TouchAction(appiumDriver).Press(300, 1525).MoveTo(300, 1850).Release().Perform();
            appiumDriver.FindElementById(RegisterComponent.TcRegisterPositiveButton).Click();
            appiumDriver.FindElementById(RegisterComponent.TcRegisterPhoneNumber)
                .SendKeys(RegisterConst.TcRegisterPhoneNumberInputValid);
            new TouchAction(appiumDriver).Press(500,1800).MoveTo(500,400).Release().Perform();
            //todo Add Two Assert
            appiumDriver.FindElementById(RegisterComponent.TcRegisterKvkk).Click();
            appiumDriver.FindElementById(RegisterComponent.TcRegisterPositiveButton).Click();
            appiumDriver.FindElementById(RegisterComponent.TcRegisterKvk).Click();
            appiumDriver.FindElementById(RegisterComponent.TcRegisterPositiveButton).Click();
            appiumDriver.FindElementById(RegisterComponent.TcRegisterActivity).Click();
            appiumDriver.FindElementById(RegisterComponent.TcRegisterPositiveButton).Click();
            appiumDriver.FindElementById(RegisterComponent.TcRegisterStartButton).Click();
        }
    }
}