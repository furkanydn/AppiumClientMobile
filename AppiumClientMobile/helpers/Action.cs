#nullable enable
using System;
using AppiumClientMobile.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using static AppiumClientMobile.Properties.Resources;

namespace AppiumClientMobile.helpers
{
    public class Action
    {
        private static AppiumDriver<AppiumWebElement>? _driver;

        public Action(DriverOptions appiumOptions)
        {
            switch (_driver)
            {
                case null:
                {
                    var serverUri = AppiumServers.StartLocalService();
                    // If you want to use it for ios use iOSDriver or android use AndroidDriver
                    _driver = new AndroidDriver<AppiumWebElement>(serverUri, appiumOptions, Env.InitTimeOutSec);
                    _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
                    break;
                }
            }
        }

        // ReSharper disable once UnusedMethodReturnValue.Global
        public static string? SendElementByAccessibilityId(string element, string action, string? keys)
        {
            if (_driver == null)
            {
                throw new NullReferenceException(ComMotivistDevelopment_Contexts_ElementNotSetted);
            }
            // Element Find
            // ReSharper disable once SuggestVarOrType_SimpleTypes
            AppiumWebElement appiumWebElement = _driver.FindElementByAccessibilityId(element);
            switch (action)
            {
                case "text": case "Text":
                    // Element Click
                    // ReSharper disable once SuggestVarOrType_BuiltInTypes
                    string? text = appiumWebElement.Text;
                    TestContext.WriteLine(element + text);
                    return text;
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
                                          ComMotivistDevelopment_Contexts_ElementSendKeys_To +
                                          keys +
                                          ComMotivistDevelopment_Contexts_ElementSendKeys_Sended);
                    break;
            }
            return null;
        }
    }
}