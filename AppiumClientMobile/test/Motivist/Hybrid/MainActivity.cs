using AppiumClientMobile.helpers;
using NUnit.Framework;
using static AppiumClientMobile.helpers.DriverWPs;
using static AppiumClientMobile.Properties.AccessibilityIds;

namespace AppiumClientMobile.test.Motivist.Hybrid
{
    [TestFixture, Order(1)]
    public class MainActivity
    {
        [OneTimeSetUp]
        public void BeforeAll()
        {
            // ReSharper disable once ObjectCreationAsStatement
            new DriverWPs(MobilePlatform.Android,MobileProject.Motivist,true);
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
            SendElementByAccessibilityId(
                ComMotivistDevelopment_NavigationMain_Index,
                "Click",
                null);
            // MainMenuIcon Click
            SendElementByAccessibilityId(
                ComMotivistDevelopment_IndexPageMainToolBar_MenuIcon,
                "Click",
                null);
            // DrawerNavigationClose Click
            SendElementByAccessibilityId(
                ComMotivistDevelopment_MainDrawerNavigation_DrawerNavigationClose,
                "Click",
                null);
            // Main UserName GetName
            string userName =
                GetElementTextByAccessibilityId(
                    ComMotivistDevelopment_IndexPageMainToolBar_UserName);
            // Check UserName is not null
            Assert.AreNotEqual(null, userName);
            // MainProfileImage Click
            SendElementByAccessibilityId(
                ComMotivistDevelopment_IndexPageMainToolBar_ProfileImage,
                "Click",
                null);
            // Header-Back Click
            SendElementByAccessibilityId(
                ComMotivistDevelopment_GeneralPages_HeaderBack,
                "Click",
                null);
            // MottoList comes here by default, first click on the Announcements due to the id hiding situation.
            // Announcements Click
            SendElementByAccessibilityId(
                ComMotivistDevelopment_IndexPageMainToolBar_Announcements,
                "Click",
                null);
            // MottoList Click
            SendElementByAccessibilityId(
                ComMotivistDevelopment_IndexPageMainToolBar_MottoList,
                "Click",
                null);
            // Motto Slider Swipe
            
        }

        [Test, Order(1)]
        public void CheckAbilityToActionsOnHorizontalScroll()
        {
            // Motion Events Swipe Right
            SwipeScreen(Direction.Down);
        }
        
        [Test, Order(2)]
        public void CheckAbilityToActionsOnHomeMission()
        {
            // Motion Events Click Todo
        }
    }
}