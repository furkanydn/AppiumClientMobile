using AppiumClientMobile.test.YuruBeIstanbul.Android.Objects.Components;
using AppiumClientMobile.test.YuruBeIstanbul.Android.Objects.Constant;
using NUnit.Framework;
using OpenQA.Selenium.Appium;

namespace AppiumClientMobile.test.YuruBeIstanbul.Android.Suites
{
    [TestFixture]
    public class Walkthrough
    {
        [Test]
        [Order(0)]
        public static void CheckWalkthroughScreenComponents(                                                                                   
            [Values(typeof(AppiumDriver<AppiumWebElement>))] AppiumDriver<AppiumWebElement> appiumDriver)
        {
            Assert.That(appiumDriver.FindElementByAccessibilityId(
                        WalkthroughComponent.TcWalkthroughAppStarting).Text, 
                Is.EqualTo(WalkthroughConst.TcWalkthroughAppStarting));
            Assert.That(appiumDriver.FindElementByAccessibilityId(
                    WalkthroughComponent.TcWalkthroughAnimationFirst).Displayed,
                Is.True);
            Assert.That(appiumDriver.FindElementByAccessibilityId(
                    WalkthroughComponent.TcWalkthroughStepText).Text,
                Is.EqualTo(WalkthroughConst.TcWalkthroughStepText));
            Assert.That(appiumDriver.FindElementByAccessibilityId(
                WalkthroughComponent.TcWalkthroughStepDesc).Text,
                Is.EqualTo(WalkthroughConst.TcWalkthroughStepDesc));
            Assert.That(appiumDriver.FindElementByAccessibilityId(
                WalkthroughComponent.TcWalkthroughAnimationSecond).Displayed,
                Is.True);
            Assert.That(appiumDriver.FindElementByAccessibilityId(
                WalkthroughComponent.TcWalkthroughExploreText).Text, 
                Is.EqualTo(WalkthroughConst.TcWalkthroughExploreText));
            Assert.That(appiumDriver.FindElementByAccessibilityId(
                WalkthroughComponent.TcWalkthroughExploreDesc).Text,
                Is.EqualTo(WalkthroughConst.TcWalkthroughExploreDesc));
            Assert.That(appiumDriver.FindElementByAccessibilityId(
                WalkthroughComponent.TcWalkthroughRewardsText).Text,
                Is.EqualTo(WalkthroughConst.TcWalkthroughRewardsText));
            Assert.That(appiumDriver.FindElementByAccessibilityId(
                WalkthroughComponent.TcWalkthroughRewardsDesc).Text,
                Is.EqualTo(WalkthroughConst.TcWalkthroughRewardsDesc));
            appiumDriver.FindElementById(WalkthroughComponent.TcWalkthroughContinueButton).Click();
        }
    }
}