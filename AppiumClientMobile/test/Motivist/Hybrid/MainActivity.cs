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

        [Test, Order(0)]
        public void CheckAbilityToActionsOnMainToolBarComponent()
        {
            ActionByElement(Commands.Click, FindMethod.ByAccessibilityId, ComMotivistDevelopment_NavigationMain_Index);
            ActionByElement(Commands.Click, FindMethod.ByAccessibilityId, ComMotivistDevelopment_IndexPageMainToolBar_MenuIcon);
            ActionByElement(Commands.Click, FindMethod.ByAccessibilityId, ComMotivistDevelopment_MainDrawerNavigation_DrawerNavigationClose);
            // Main UserName GetName
            Assert.That(
                ActionByElement(Commands.Text, FindMethod.ByAccessibilityId,
                    ComMotivistDevelopment_IndexPageMainToolBar_UserName), Is.Not.EqualTo(null));
            ActionByElement(Commands.Click, FindMethod.ByAccessibilityId, ComMotivistDevelopment_IndexPageMainToolBar_ProfileImage);
            ActionByElement(Commands.Click, FindMethod.ByAccessibilityId, ComMotivistDevelopment_GeneralPages_HeaderBack);
            ActionByElement(Commands.Click, FindMethod.ByAccessibilityId,
                ComMotivistDevelopment_IndexPageMainToolBar_Announcements);
            // MottoList comes here by default, first click on the Announcements due to the id hiding situation.
            ActionByElement(Commands.Click, FindMethod.ByAccessibilityId, ComMotivistDevelopment_IndexPageMainToolBar_MottoList);
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