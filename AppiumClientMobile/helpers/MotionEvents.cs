using System;
using System.Diagnostics;
using System.Drawing;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Interfaces;
using OpenQA.Selenium.Appium.MultiTouch;

// ReSharper disable SuggestVarOrType_BuiltInTypes
// ReSharper disable SuggestVarOrType_SimpleTypes

namespace AppiumClientMobile.helpers
{
    public class MotionEvents
    {
        private static AppiumDriver<AppiumWebElement> _driver;
        // to do
        public static void ScrollDown(double startY, double endY)
        {
            Size dimension = _driver.Manage().Window.Size;
            // Calculation of X coordinate and Y coordinate on the screen
            double scrollHeightStart = dimension.Height * startY;
            int scrollStart = (int) scrollHeightStart;
            double scrollHeightEnd = dimension.Height * endY;
            int scrollEnd = (int) scrollHeightEnd;
            
            new TouchAction((IPerformsTouchActions) _driver)
                .Press(0, scrollStart)
                .Wait(2000)
                .MoveTo(0,scrollEnd)
                .Release()
                .Perform();
        }
    }
}