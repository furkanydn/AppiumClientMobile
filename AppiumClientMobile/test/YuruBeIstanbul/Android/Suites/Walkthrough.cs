using System;
using AppiumClientMobile.helpers;
using AppiumClientMobile.Helpers;
using AppiumClientMobile.test.YuruBeIstanbul.Android.Objects.Components;
using AppiumClientMobile.test.YuruBeIstanbul.Android.Objects.Constant;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;

namespace AppiumClientMobile.test.YuruBeIstanbul.Android.Suites
{
    [TestFixture]
    public class Walkthrough
    {
        private static AndroidDriver<IWebElement> _androidDriver;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            var capabilities = Caps.GetAndroidYuruBeIstanbulCapabilities();
            var serverUri = AppiumServers.StartLocalService();
            _androidDriver = new AndroidDriver<IWebElement>(serverUri, capabilities, Env.InitTimeOutSec);
            _androidDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }

        [Test, Order(0)]
        public void CheckWalkthroughScreenComponents()
        {
            Assert.That(_androidDriver.FindElementByAccessibilityId(
                        WalkthroughComponent.TcWalkthroughAppStarting).Text, 
                Is.EqualTo(WalkthroughConst.TcWalkthroughAppStarting));
            Assert.That(_androidDriver.FindElementByAccessibilityId(
                    WalkthroughComponent.TcWalkthroughAnimationFirst).Displayed,
                Is.True);
            Assert.That(_androidDriver.FindElementByAccessibilityId(
                    WalkthroughComponent.TcWalkthroughStepText).Text,
                Is.EqualTo(WalkthroughConst.TcWalkthroughStepText));
            Assert.That(_androidDriver.FindElementByAccessibilityId(
                WalkthroughComponent.TcWalkthroughStepDesc).Text,
                Is.EqualTo(WalkthroughConst.TcWalkthroughStepDesc));
            Assert.That(_androidDriver.FindElementByAccessibilityId(
                WalkthroughComponent.TcWalkthroughAnimationSecond).Displayed,
                Is.True);
            Assert.That(_androidDriver.FindElementByAccessibilityId(
                WalkthroughComponent.TcWalkthroughExploreText).Text, 
                Is.EqualTo(WalkthroughConst.TcWalkthroughExploreText));
            Assert.That(_androidDriver.FindElementByAccessibilityId(
                WalkthroughComponent.TcWalkthroughExploreDesc).Text,
                Is.EqualTo(WalkthroughConst.TcWalkthroughExploreDesc));
            Assert.That(_androidDriver.FindElementByAccessibilityId(
                WalkthroughComponent.TcWalkthroughRewardsText).Text,
                Is.EqualTo(WalkthroughConst.TcWalkthroughRewardsText));
            Assert.That(_androidDriver.FindElementByAccessibilityId(
                WalkthroughComponent.TcWalkthroughRewardsDesc).Text,
                Is.EqualTo(WalkthroughConst.TcWalkthroughRewardsDesc));
            _androidDriver.FindElementById(WalkthroughComponent.TcWalkthroughContinueButton).Click();
        }
    }
}