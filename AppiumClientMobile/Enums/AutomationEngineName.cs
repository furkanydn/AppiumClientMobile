using OpenQA.Selenium.Appium.Enums;

namespace AppiumClientMobile.Enums
{
    public static class AutomationEngineName
    {
        // ReSharper disable once StaticMemberInitializerReferesToMemberBelow
        public static readonly object XcuiTest = AutomationName.iOSXcuiTest;
        public static readonly object UiAutomator2 = AutomationName.AndroidUIAutomator2;
        public static string AndroidEspresso = "Espresso";
    }
}
