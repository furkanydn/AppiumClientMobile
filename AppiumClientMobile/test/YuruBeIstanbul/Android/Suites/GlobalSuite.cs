using AppiumClientMobile.helpers;
using AppiumClientMobile.Helpers;
using NUnit.Framework;
using OpenQA.Selenium.Appium;

namespace AppiumClientMobile.test.YuruBeIstanbul.Android.Suites
{
    [TestFixture]
    [Description("Opened in order to keep track of all test classes in one place.")]
    public class GlobalSuite
    {
        // ReSharper disable once MemberCanBePrivate.Global
        public static AppiumDriver<AppiumWebElement> Driver { get; set; }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            new DriverWPs(DriverWPs.MobilePlatform.Android, DriverWPs.MobileProject.Ybi, true);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown() => AppiumServers.StopLocalService();

        /// <summary>
        /// If necessary, you can test only the components on this page as a singleton. Just make the AppActivity value in the Capabilities class the Activity you want to go to.
        /// </summary>
        [Test]
        [Order(0)]
        public static void Walkthrough() => Suites.Walkthrough.CheckWalkthroughScreenComponents(Driver);

        [Test]
        [Order(1)]
        public static void Register() => Suites.Register.CheckRegisterScreenComponents(Driver);
    }
}