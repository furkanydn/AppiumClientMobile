using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using AppiumClientMobile.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.iOS;
using OpenQA.Selenium.Appium.MultiTouch;
using static AppiumClientMobile.Properties.Resources;

namespace AppiumClientMobile.helpers
{
    public class DriverWPs
    {
        public static AppiumDriver<AppiumWebElement> Driver { get; set; }

        /// <summary>
        /// Initializes a new instance of the Action class.
        /// You can use the mobile platform, mobile project name and application package for the driver.
        /// </summary>
        /// <param name="mobilePlatform">Mobile platform to be used with this object</param>
        /// <param name="mobileProject"></param>
        /// <param name="appPackageRequired">The requirement of the application package is controlled by this object. <br/> 0 is sent with the application package and 1 without the application package.</param>
        /// <example>
        /// <code>
        /// [OneTimeSetUp]
        /// public void BeforeAll()
        /// {
        ///     new DriverWPs(MobilePlatform.Android, MobileProject.Motivist, true);
        /// }
        /// </code>
        /// </example>
        public DriverWPs(MobilePlatform mobilePlatform, MobileProject mobileProject,bool appPackageRequired)
        {
            switch (Driver)
            {
                case null:
                {
                    AppiumOptions appiumOptions;
                    switch (mobilePlatform)
                    {
                        case MobilePlatform.Android:
                            switch (mobileProject)
                            {
                                case MobileProject.Motivist:
                                    appiumOptions = appPackageRequired
                                        ? Caps.GetMotivistCapabilities(Caps.Os.Android, true)
                                        : Caps.GetMotivistCapabilities(Caps.Os.Android, false);
                                    DriverManager(MobilePlatform.Android, appiumOptions);
                                    break;
                                case MobileProject.Ybi:
                                    appiumOptions = appPackageRequired
                                        ? Caps.GetYuruBeIstanbulCapabilities(Caps.Os.Android, true)
                                        : Caps.GetYuruBeIstanbulCapabilities(Caps.Os.Android, false);
                                    DriverManager(MobilePlatform.Android, appiumOptions);
                                    break;
                                default:
                                    throw new ArgumentOutOfRangeException(nameof(mobileProject), mobileProject, null);
                            }
                            break;
                        case MobilePlatform.iOS:
                            switch (mobileProject)
                            {
                                case MobileProject.Motivist:
                                    appiumOptions = appPackageRequired
                                        ? Caps.GetMotivistCapabilities(Caps.Os.iOS, true)
                                        : Caps.GetMotivistCapabilities(Caps.Os.iOS, false);
                                    DriverManager(MobilePlatform.iOS,appiumOptions);
                                    break;
                                case MobileProject.Ybi:
                                    appiumOptions = appPackageRequired
                                        ? Caps.GetYuruBeIstanbulCapabilities(Caps.Os.iOS, true)
                                        : Caps.GetYuruBeIstanbulCapabilities(Caps.Os.iOS, false);
                                    DriverManager(MobilePlatform.iOS,appiumOptions);
                                    break;
                                default:
                                    throw new ArgumentOutOfRangeException(nameof(mobileProject), mobileProject, null);
                            }
                            break;
                        default:
                            throw new ArgumentOutOfRangeException(nameof(mobilePlatform), mobilePlatform, null);
                    }
                    break;
                }
            }
        }

        public enum MobilePlatform
        {
            Android,
            // ReSharper disable once InconsistentNaming
            iOS
        }

        public enum MobileProject
        {
            Motivist,
            Ybi
        }

        /// <summary>
        /// DriverManager is a method that provides the parameters required when installing the driver.
        /// </summary>
        /// <param name="mobilePlatform">One of the necessary parameters is one of the steps for creating the driver according to the mobile platform.</param>
        /// <param name="appiumOptions">It is a variable that contains the necessary startup settings.</param>
        /// <exception cref="ArgumentOutOfRangeException">The exception that is thrown when the value of an argument is outside the allowable range of values as defined by the invoked method.</exception>
        private static void DriverManager(MobilePlatform mobilePlatform,DriverOptions appiumOptions)
        {
            Uri serverUri;
            switch (mobilePlatform)
            {
                case MobilePlatform.Android:
                    serverUri = AppiumServers.StartLocalService();
                    Driver = new AndroidDriver<AppiumWebElement>(serverUri, appiumOptions, Env.InitTimeOutSec);
                    Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMinutes(1);
                    Driver.LaunchApp();
                    break;
                case MobilePlatform.iOS:
                    serverUri = AppiumServers.StartLocalService();
                    Driver = new IOSDriver<AppiumWebElement>(serverUri, appiumOptions, Env.InitTimeOutSec);
                    Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMinutes(1);
                    Driver.LaunchApp();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(mobilePlatform), mobilePlatform, null);
            }
        }

        public static void ActionByElement(Commands commands, FindMethod findMethod, string element,string keys=null)
        {
            if (Driver == null) throw new NullReferenceException("It receives an error because the required options are not met.");
            switch (commands)
            {
                    
                case Commands.Click:
                    switch (findMethod)
                    {
                        case FindMethod.ById:
                            Driver.FindElementById(element).Click();
                            TestContext.WriteLine($"{DateTime.Now:s} | Click | ById | {element}");
                            break;
                        case FindMethod.ByName:
                            Driver.FindElementByName(element).Click();
                            TestContext.WriteLine($"{DateTime.Now:s} | Click | ByName | {element}");
                            break;
                        case FindMethod.ByAccessibilityId:
                            Driver.FindElementByAccessibilityId(element).Click();
                            TestContext.WriteLine($"{DateTime.Now:s} | Click | ByAccessibilityId | {element}");
                            break;
                        case FindMethod.ByXPath:
                            Driver.FindElementByXPath(element).Click();
                            TestContext.WriteLine($"{DateTime.Now:s} | Click | ByXPath | {element}");
                            break;
                        case FindMethod.ByLinkText:
                            Driver.FindElementByXPath(element).Click();
                            TestContext.WriteLine($"{DateTime.Now:s} | Click | ByLinkText | {element}");
                            break;
                        default:
                            throw new ArgumentOutOfRangeException(nameof(findMethod), findMethod, null);
                    }
                    break;
                case Commands.SendKeys:
                    break;
                case Commands.Text:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(commands), commands, null);
            }
        }

        public enum Commands
        {
            Click,
            SendKeys,
            Text
        }

        public enum FindMethod
        {
            ById,
            ByName,
            ByAccessibilityId,
            ByXPath,
            ByLinkText
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
        public static void SendElementByAccessibilityId(string element, string action, string keys=null)
        {
            if (Driver == null) throw new NullReferenceException(ComMotivistDevelopment_Contexts_ElementNotSetted);
            Debug.Assert(Driver != null, nameof(Driver) + " != null");
            var appiumWebElement = Driver.FindElementByAccessibilityId(element);
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
            if (Driver == null) throw new NullReferenceException(ComMotivistDevelopment_Contexts_ElementNotSetted);
            Debug.Assert(Driver != null, nameof(Driver) + " != null");
            // Element Find
            AppiumWebElement appiumWebElement = Driver.FindElementByAccessibilityId(element);
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
            Debug.Assert(Driver != null, nameof(Driver) + " != null");
            // Animation default time:
            //  - Android: 300 ms
            //  - iOS: 200 ms
            const int animationTime = 300; // ms
            const int pressTime = 200; // ms
            int optionX;
            int optionY;
            // init screen variables
            Size dimension = Driver.Manage().Window.Size;
            // Calculation of X coordinate and Y coordinate on the screen
            int scrollHeight = dimension.Height / 2;
            int scrollWidth = dimension.Width / 2;

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
                new TouchAction(Driver)
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
            catch (ThreadInterruptedException)
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
            Debug.Assert(Driver != null, nameof(Driver) + " != null");
            // init element variables
            var elementor = Driver.FindElementByAccessibilityId(element);
            int elementWidth = elementor.Size.Width;
            int elementHeight = elementor.Size.Height;
            TestContext.WriteLine("Element Size > Width: "+elementWidth+"-Height: " +elementHeight);
            int calcStartWidth = (elementWidth / 10) * 8;
            int calcHeight = (elementHeight / 2);
            int calcEndWidth = elementWidth / 10;

            switch (direction)
            {
                case Offset.Right:
                    new TouchAction(Driver).Press(calcStartWidth,calcHeight).MoveTo(calcEndWidth,calcHeight).Release().Perform();
                    TestContext.WriteLine("Element Scroll > StartX: "+calcStartWidth+ "StartY: " +calcHeight+"-EndX: " +calcEndWidth+"-EndY: " +calcHeight);
                    break;
                case Offset.Left:
                    new TouchAction(Driver).Press(calcEndWidth,calcHeight).MoveTo(calcStartWidth,calcHeight).Release().Perform();
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
                string unused = process.StandardOutput.ReadLine() ?? string.Empty;
                //textContext
            }
            process.WaitForExit();
        }
    }
}