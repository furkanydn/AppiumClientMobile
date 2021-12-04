using System.Threading;
using AppiumClientMobile.helpers;
using NUnit.Framework;
using OpenQA.Selenium.Interactions;
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
        public void CheckAbilityToActionsOnMainToolBarComponent()
        {
            // NavigationMainIndex Click
            DriverWithParams.SendElementByAccessibilityId(
                ComMotivistDevelopment_NavigationMain_Index,
                "Click",
                null);
            // MainMenuIcon Click
            DriverWithParams.SendElementByAccessibilityId(
                ComMotivistDevelopment_IndexPageMainToolBar_MenuIcon,
                "Click",
                null);
            // DrawerNavigationClose Click
            DriverWithParams.SendElementByAccessibilityId(
                ComMotivistDevelopment_MainDrawerNavigation_DrawerNavigationClose,
                "Click",
                null);
            // MainProfileImage Click
            DriverWithParams.SendElementByAccessibilityId(
                ComMotivistDevelopment_IndexPageMainToolBar_ProfileImage,
                "Click",
                null);
            // Header-Back Click
            DriverWithParams.SendElementByAccessibilityId(
                ComMotivistDevelopment_GeneralPages_HeaderBack,
                "Click",
                null);
            // MottoList comes here by default, first click on the Announcements due to the id hiding situation.
            // Announcements Click
            DriverWithParams.SendElementByAccessibilityId(
                ComMotivistDevelopment_IndexPageMainToolBar_Announcements,
                "Click",
                null);
            // MottoList Click
            DriverWithParams.SendElementByAccessibilityId(
                ComMotivistDevelopment_IndexPageMainToolBar_MottoList,
                "Click",
                null);
        }

        [Test, Order(1)]
        public void CheckAbilityToActionsOnMottoAnd()
        {
            //Actions actions = new Actions(driver)
        }
    }
}