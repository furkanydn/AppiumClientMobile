#nullable enable
using System;
using System.Diagnostics;
using AppiumClientMobile.Helpers;
using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.iOS;
using static AppiumClientMobile.Properties.Resources;

namespace AppiumClientMobile.helpers
{
    public class DriverWithParams
    {
        private static AppiumDriver<AppiumWebElement>? _driver;
        /// <summary>
        /// Initializes a new instance of the Action class.
        /// You can use the mobile platform and application package for the driver.
        /// </summary>
        /// <param name="mobilePlatform">Mobile platform to be used with this object</param>
        /// <param name="appPackageRequired">The requirement of the application package is controlled by this object. <br/> 0 is sent with the application package and 1 without the application package.</param>
        /// <example>
        /// <code>
        /// [OneTimeSetUp]
        /// public void BeforeAll()
        /// {
        ///     new CreateNewAppiumServerWithParams(0,1);
        /// }
        /// </code>
        /// </example>
        public DriverWithParams(byte mobilePlatform, byte appPackageRequired)
        {
            switch (_driver)
            {
                case null:
                {
                    AppiumOptions appiumOptions;
                    Uri serverUri;
                    switch (mobilePlatform)
                    {
                        case 0 when appPackageRequired == 0:
                            appiumOptions = Caps.GetAndroidUiAutomatorCapsWithAppPackage();
                            serverUri = AppiumServers.StartLocalService();
                            _driver = new AndroidDriver<AppiumWebElement>(serverUri, appiumOptions, Env.InitTimeOutSec);
                            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
                            _driver.LaunchApp();
                            break;
                        case 0:
                            appiumOptions = Caps.GetAndroidUiAutomatorCaps();
                            serverUri = AppiumServers.StartLocalService();
                            _driver = new AndroidDriver<AppiumWebElement>(serverUri, appiumOptions, Env.InitTimeOutSec);
                            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
                            break;
                        default:
                        {
                            switch (appPackageRequired)
                            {
                                case 0:
                                    appiumOptions = Caps.GetIosXcuiTestCapsWithAppPackage();
                                    serverUri = AppiumServers.StartLocalService();
                                    _driver = new IOSDriver<AppiumWebElement>(serverUri, appiumOptions, Env.InitTimeOutSec);
                                    _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
                                    _driver.LaunchApp();
                                    break;
                                default:
                                    appiumOptions = Caps.GetIosXcuiTestCaps();
                                    serverUri = AppiumServers.StartLocalService();
                                    _driver = new IOSDriver<AppiumWebElement>(serverUri, appiumOptions, Env.InitTimeOutSec);
                                    _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
                                    break;
                            }
                            break;
                        }
                    }
                    break;
                }
            }
        }
        private static void CheckDriverNull()
        {
            if (_driver == null)
            {
                throw new NullReferenceException(ComMotivistDevelopment_Contexts_ElementNotSetted);
            }
        }
        
        // ReSharper disable once UnusedMethodReturnValue.Global
        public static void SendElementByAccessibilityId(string element, string action, string? keys)
        {
            CheckDriverNull();
            // Element Find
            // ReSharper disable once SuggestVarOrType_SimpleTypes
            Debug.Assert(_driver != null, nameof(_driver) + " != null");
            AppiumWebElement appiumWebElement = _driver.FindElementByAccessibilityId(element);
            switch (action)
            {
                case "click": case "Click":
                    // Element Click
                    appiumWebElement.Click();
                    // Element See Action
                    TestContext.WriteLine(element + ComMotivistDevelopment_Contexts_ElementClicked);
                    break;
                case "sendkeys":  case "SendKeys":
                    // Element SendKeys
                    appiumWebElement.SendKeys(keys);
                    TestContext.WriteLine(element + 
                                          ComMotivistDevelopment_Contexts_ElementSendKeys_To + " " +
                                          keys + " " +
                                          ComMotivistDevelopment_Contexts_ElementSendKeys_Sended);
                    break;
            }
        }

        public static string GetElementTextByAccessibilityId(string element)
        {
            CheckDriverNull();
            Debug.Assert(_driver != null, nameof(_driver) + " != null");
            // Element Find
            AppiumWebElement appiumWebElement = _driver.FindElementByAccessibilityId(element);
            // ReSharper disable once SuggestVarOrType_BuiltInTypes
            string text = appiumWebElement.Text;
            // Element See Action
            TestContext.WriteLine(element + " " + text);
            // Element Return Value
            return text;
        }
    }
}