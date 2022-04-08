using NUnit.Framework;
using OpenQA.Selenium.Appium;

namespace AppiumClientMobile.test.YuruBeIstanbul.Android.Suites
{
    [TestFixture]
    public class Register
    {
        [Test]
        [Order(0)]
        public static void CheckRegisterScreenComponents([Values(typeof(AppiumDriver<AppiumWebElement>))] AppiumDriver<AppiumWebElement> appiumDriver)
        {
            //appiumDriver.FindElementById()
        }
    }
}