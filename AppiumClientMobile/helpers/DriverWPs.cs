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

        public static string ActionByElement(Commands commands, FindMethod findMethod, string element,string keys=null)
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
                    switch (findMethod)
                    {
                        case FindMethod.ById:
                            Driver.FindElementById(element).SendKeys(keys);
                            TestContext.WriteLine($"{DateTime.Now:s} | SendKeys | ById | {element}");
                            break;
                        case FindMethod.ByName:
                            Driver.FindElementByName(element).SendKeys(keys);
                            TestContext.WriteLine($"{DateTime.Now:s} | SendKeys | ByName | {element}");
                            break;
                        case FindMethod.ByAccessibilityId:
                            Driver.FindElementByAccessibilityId(element).SendKeys(keys);
                            TestContext.WriteLine($"{DateTime.Now:s} | SendKeys | ByAccessibilityId | {element}");
                            break;
                        case FindMethod.ByXPath:
                            Driver.FindElementByXPath(element).SendKeys(keys);
                            TestContext.WriteLine($"{DateTime.Now:s} | SendKeys | ByXPath | {element}");
                            break;
                        case FindMethod.ByLinkText:
                            Driver.FindElementByXPath(element).SendKeys(keys);
                            TestContext.WriteLine($"{DateTime.Now:s} | SendKeys | ByLinkText | {element}");
                            break;
                        default:
                            throw new ArgumentOutOfRangeException(nameof(findMethod), findMethod, null);
                    }
                    break;
                case Commands.Text:
                    string text;
                    switch (findMethod)
                    {
                        case FindMethod.ById:
                            text = Driver.FindElementById(element).Text;
                            TestContext.WriteLine($"{DateTime.Now:s} | SendKeys | ById | {element}");
                            return text;
                        case FindMethod.ByName:
                            text = Driver.FindElementByName(element).Text;
                            TestContext.WriteLine($"{DateTime.Now:s} | SendKeys | ByName | {element}");
                            return text;
                        case FindMethod.ByAccessibilityId:
                            text = Driver.FindElementByAccessibilityId(element).Text;
                            TestContext.WriteLine($"{DateTime.Now:s} | SendKeys | ByAccessibilityId | {element}");
                            return text;
                        case FindMethod.ByXPath:
                            text = Driver.FindElementByXPath(element).Text;
                            TestContext.WriteLine($"{DateTime.Now:s} | SendKeys | ByXPath | {element}");
                            return text;
                        case FindMethod.ByLinkText:
                            text = Driver.FindElementByXPath(element).Text;
                            TestContext.WriteLine($"{DateTime.Now:s} | SendKeys | ByLinkText | {element}");
                            return text;
                        default:
                            throw new ArgumentOutOfRangeException(nameof(findMethod), findMethod, null);
                    }
                default:
                    throw new ArgumentOutOfRangeException(nameof(commands), commands, null);
            }
            return null;
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
            var elementWidth = elementor.Size.Width;
            var elementHeight = elementor.Size.Height;
            TestContext.WriteLine("Element Size > Width: "+elementWidth+"-Height: " +elementHeight);
            var calcStartWidth = (elementWidth / 10) * 8;
            var calcHeight = (elementHeight / 2);
            var calcEndWidth = elementWidth / 10;

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
            var process = Process.Start(processInfo) ?? throw new InvalidOperationException();
            while (!process.StandardOutput.EndOfStream)
            {
                var unused = process.StandardOutput.ReadLine() ?? string.Empty;
                //textContext
            }
            process.WaitForExit();
        }
    }
}