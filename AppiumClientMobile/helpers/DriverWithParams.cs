#nullable enable
using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using AppiumClientMobile.Helpers;
using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.iOS;
using OpenQA.Selenium.Appium.MultiTouch;
using static AppiumClientMobile.Properties.Resources;
// ReSharper disable SuggestVarOrType_BuiltInTypes
// ReSharper disable SuggestVarOrType_SimpleTypes

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
        ///     new DriverWithParams(0,1);
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
        /// <summary>
        /// It's the method for detecting whether or not the Driver item is functional.
        /// </summary>
        /// <exception cref="NullReferenceException">The exception that is thrown when there is an attempt to dereference a null object reference.</exception>
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
                    Thread.Sleep(1000);
                    // Element See Action
                    TestContext.WriteLine(element + ComMotivistDevelopment_Contexts_ElementClicked);
                    break;
                case "sendkeys":  case "SendKeys":
                    // Element SendKeys
                    appiumWebElement.SendKeys(keys);
                    Thread.Sleep(1000);
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

        /// <summary>
        /// Swipe has start and end points. The start point of swipe is most important. The following elements may prevent swipe start: - application interface/menu e.g. header or footer - elements that are waiting tap and do not pass touch to scroll view.
        /// Performs swipe from the center of screen
        /// </summary>
        /// <param name="direction">The direction of swipe</param>
        /// <example>
        /// <code>
        /// DriverWithParams.SwipeScreen(DriverWithParams.Direction.Down);
        /// </code>
        /// </example>
        /// <footer><a href="http://appium.io/docs/en/commands/interactions/touch/scroll/">Scroll based motion events</a></footer>
        public static void SwipeScreen(Direction direction)
        {
            TestContext.WriteLine("Swipe Screen(): Direction: " + direction);
            Debug.Assert(_driver != null, nameof(_driver) + " != null");
            // Animation default time:
            //  - Android: 300 ms
            //  - iOS: 200 ms
            const int animationTime = 300; // ms
            const int pressTime = 200; // ms
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
                    optionX = scrollWidth;
                    optionY = (int) (scrollHeight * 1.75);
                    break;
                case Direction.Down: // center of footer
                    optionX = scrollWidth;
                    optionY = scrollHeight  / 2 ;
                    break;
                case Direction.Left:
                    optionX = scrollWidth / 3;
                    optionY = scrollHeight;
                    break;
                case Direction.Right:
                    optionX = (int) (scrollWidth * 1.5);
                    optionY = scrollHeight;
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

        public enum Offset
        {
            Left,
            Right
        }
        // todo just use right and left for element
        public static void ScrollToElement(string element, Offset direction)
        {
            TestContext.WriteLine("Scroll on the: " + element);
            Debug.Assert(_driver != null, nameof(_driver) + " != null");
            // init element variables
            var elementor = _driver.FindElementByAccessibilityId(element);
            int elementWidth = elementor.Size.Width;
            int elementHeight = elementor.Size.Height;
            TestContext.WriteLine("Element Size > Width: "+elementWidth+"-Height: " +elementHeight);
            int calcStartWidth = (elementWidth / 10) * 8;
            int calcHeight = (elementHeight / 2);
            int calcEndWidth = elementWidth / 10;

            switch (direction)
            {
                case Offset.Right:
                    new TouchAction(_driver).Press(calcStartWidth,calcHeight).MoveTo(calcEndWidth,calcHeight).Release().Perform();
                    TestContext.WriteLine("Element Scroll > StartX: "+calcStartWidth+ "StartY: " +calcHeight+"-EndX: " +calcEndWidth+"-EndY: " +calcHeight);
                    break;
                case Offset.Left:
                    new TouchAction(_driver).Press(calcEndWidth,calcHeight).MoveTo(calcStartWidth,calcHeight).Release().Perform();
                    TestContext.WriteLine("Element Scroll > StartX: "+calcEndWidth+ "StartY: " +calcHeight+"-EndX: " +calcStartWidth+"-EndY: " +calcHeight);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(direction), direction, @"not supported.");
            }
            
        }

        // run script methods
        public static void RunShScript()
        {
            const string command = "sh";
            var scriptFile = "filepath.sh";
            const string arguments = "filepath.sh";
            var processInfo = new ProcessStartInfo()
            {
                FileName = command,
                Arguments = arguments,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                CreateNoWindow = true
            };
            Process process = Process.Start(processInfo) ?? throw new InvalidOperationException();
            while (!process.StandardOutput.EndOfStream)
            {
                string result = process.StandardOutput.ReadLine() ?? string.Empty;
                // textcontext
            }
            process.WaitForExit();
        }
    }
}