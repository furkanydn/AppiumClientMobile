using AppiumClientMobile.helpers;
using NUnit.Framework;
using OpenQA.Selenium.Appium;
using static AppiumClientMobile.Properties.AccessibilityIds;
using Action = AppiumClientMobile.helpers.Action;

namespace AppiumClientMobile.test.Motivist.Hybrid
{
    [TestFixture, Order(1)]
    public class MainActivity
    {
        [OneTimeSetUp]
        public void BeforeAll()
        {
            // ReSharper disable once SuggestVarOrType_SimpleTypes
            AppiumOptions appiumOptions = Caps.GetAndroidUiAutomatorCaps();
            // ReSharper disable once ObjectCreationAsStatement
            new Action(appiumOptions);
        }
        
        [SetUp]
        public void SetUp()
        {
            //If we want the application to load in every test case, remove the comment line here.
            //_driver?.LaunchApp();
        }

        [TearDown]
        public void TearDown()
        {
            //If we want the application to be closed in every test case, remove the comment line here.
            //_driver.CloseApp(); 
            //_driver.ResetApp();
        }

        [Test, Order(0)]
        public void CheckAbilityToClickOnMainViewBottomBarButton()
        {
            // NavigationMainIndex Click
            Action.SendElementByAccessibilityId(
                ComMotivistDevelopment_CheckAbilityToClickOnMainViewBottomBarButton_NavigationMainIndex,
                "Click",
                null);
            // _driver.FindElementByAccessibilityId(
            //         ComMotivistDevelopment_CheckAbilityToClickOnMainViewBottomBarButton_NavigationMainBusinessGoals)
            //     .Click();
            // _driver.FindElementByAccessibilityId(
            //         ComMotivistDevelopment_CheckAbilityToClickOnMainViewBottomBarButton_NavigationMainIndex)
            //     .Click();
            // _driver.FindElementByAccessibilityId(
            //         ComMotivistDevelopment_CheckAbilityToClickOnMainViewBottomBarButton_NavigationMainMarket)
            //     .Click();
            // _driver.FindElementByAccessibilityId(
            //         ComMotivistDevelopment_CheckAbilityToClickOnMainViewBottomBarButton_NavigationMainNewsfeeds)
            //     .Click();
        }
    }
}