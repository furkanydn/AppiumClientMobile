#nullable enable
using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using AppiumClientMobile.Helpers;
using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Interfaces;
using OpenQA.Selenium.Appium.iOS;
using OpenQA.Selenium.Appium.MultiTouch;
using static AppiumClientMobile.Properties.Resources;

// ReSharper disable once SuggestVarOrType_SimpleTypes
// ReSharper disable once SuggestVarOrType_BuiltInTypes

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

        /// <summary>
        /// Send a sequence of key strokes to an element or Click element at its center point.
        /// </summary>
        /// <param name="element">An Accessibility Id selector, finds the first of elements that match the Accessibility Id selector supplied</param>
        /// <param name="action">Actions of the session to route the command to</param>
        /// <param name="keys">The sequence of keys to type. An array must be provided. The server should flatten the array items to a single string to be typed</param>
        /// <returns>IWebElement object so that you can interact that object</returns>
        /// <example>
        /// <code>
        /// DriverWithParams.SendElementByAccessibilityId( element , action , keys);
        /// </code>
        /// </example>
        // ReSharper disable once UnusedMethodReturnValue.Global
        public static void SendElementByAccessibilityId(string element, string action, string? keys)
        {
            CheckDriverNull();
            // Element Find
            Debug.Assert(_driver != null, nameof(_driver) + " != null");
            AppiumWebElement appiumWebElement = _driver.FindElementByAccessibilityId(element);
            switch (action)
            {
                case "click": case "Click":
                    // Element Click
                    appiumWebElement.Click();
                    Thread.Sleep(500);
                    // Element See Action
                    TestContext.WriteLine(element + ComMotivistDevelopment_Contexts_ElementClicked);
                    break;
                case "sendkeys":  case "SendKeys":
                    // Element SendKeys
                    appiumWebElement.SendKeys(keys);
                    Thread.Sleep(500);
                    TestContext.WriteLine(element + 
                                          ComMotivistDevelopment_Contexts_ElementSendKeys_To + " " +
                                          keys + " " +
                                          ComMotivistDevelopment_Contexts_ElementSendKeys_Sended);
                    break;
            }
        }

        /// <summary>
        /// Returns visible text for element
        /// </summary>
        /// <param name="element">Accessibility ID of the element to get the text from</param>
        /// <returns>Returns the visible text for the element.</returns>
        /// <example>
        /// <code>
        /// DriverWithParams.GetElementTextByAccessibilityId( element);
        /// </code>
        /// </example>
        public static string GetElementTextByAccessibilityId(string element)
        {
            CheckDriverNull();
            Debug.Assert(_driver != null, nameof(_driver) + " != null");
            // Element Find
            AppiumWebElement appiumWebElement = _driver.FindElementByAccessibilityId(element);
            string text = appiumWebElement.Text;
            // Element See Action
            TestContext.WriteLine(element + " " + text);
            // Element Return Value
            return text;
        }
        
        public static void SwipeScreen(Direction direction)
        {
            TestContext.WriteLine("Swipe Screen(): direction: " + direction);
            Debug.Assert(_driver != null, nameof(_driver) + " != null");
            // Animation default time:
            //  - Android: 300 ms
            //  - iOS: 200 ms
            const int animationTime = 200; // ms
            const int pressTime = 200; // ms
            const int edgeBorder = 12; // avoid edges
            var optionX = 0;
            var optionY = 0;
            // init screen variables
            Size dimension = _driver.Manage().Window.Size;
            // Calculation of X coordinate and Y coordinate on the screen
            int scrollHeight = (int) (dimension.Height / 2);
            int scrollWidth = (int) (dimension.Width / 2);

            switch (direction)
            {
                case Direction.Up: // center of header
                    optionX = scrollWidth / 2;
                    optionY = edgeBorder;
                    break;
                case Direction.Down: // center of footer
                    optionX = scrollWidth - edgeBorder;
                    optionY = scrollHeight  / 2 ;
                    break;
                case Direction.Left:
                    optionX = edgeBorder;
                    optionY = scrollHeight / 2;
                    break;
                case Direction.Right:
                    optionX = scrollWidth - edgeBorder;
                    optionY = scrollHeight / 2;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(direction), direction, @"not supported.");
            }
            // execute swipe using TouchAction
            try
            {
                new TouchAction(_driver)
                    .Press(scrollWidth,scrollHeight)
                    .Wait(pressTime)
                    .MoveTo(optionX,optionY)
                    .Release()
                    .Perform();
                TestContext.WriteLine("Swipe Screen(): Press "+ scrollWidth + " - " + scrollHeight);
                TestContext.WriteLine("Swipe Screen(): MoveTo "+ optionX + " - " + optionY);
            }
            catch (Exception e)
            {
                TestContext.WriteLine("Swipe Screen(): TouchAction Failed\n" + e.Message);
                throw;
            }
            // always allow swipe action to complete
            try
            {
                Thread.Sleep(animationTime);
            }
            catch (ThreadInterruptedException e)
            {
                // ignore
            }
        }
        
        public enum Direction
        {
            Up,
            Down,
            Left,
            Right
        }
    }
}