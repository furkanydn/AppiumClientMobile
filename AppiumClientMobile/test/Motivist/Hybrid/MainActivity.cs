using System.Threading;
using AppiumClientMobile.helpers;
using NUnit.Framework;
using static AppiumClientMobile.Properties.AccessibilityIds;
using static AppiumClientMobile.Enums.GeneralDesiredCaps;

namespace AppiumClientMobile.test.Motivist.Hybrid
{
    [TestFixture, Order(1)]
    public class MainActivity
    {
        [OneTimeSetUp]
        public void BeforeAll()
        {
            // ReSharper disable once ObjectCreationAsStatement
            new DriverWithParams(mobilePlatform: AppiumMobilePlatform, 1);
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
            DriverWithParams.SendElementByAccessibilityId(
                ComMotivistDevelopment_CheckAbilityToClickOnMainViewBottomBarButton_NavigationMainIndex,
                "Click",
                null);
            // mainToolBar_0 Click
            DriverWithParams.SendElementByAccessibilityId(
                ComMotivistDevelopment_IndexPageMainToolBar_ToolBarButtonZero,
                "Click",
                null);
            Thread.Sleep(1000);
            DriverWithParams.SendElementByAccessibilityId(
                ComMotivistDevelopment_IndexPageMainToolBar_ToolBarButtonOne,
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