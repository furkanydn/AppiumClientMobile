using AppiumClientMobile.helpers;
using NUnit.Framework;
using static AppiumClientMobile.Properties.AccessibilityIds;
using static AppiumClientMobile.Properties.Resources;
using static AppiumClientMobile.Enums.GeneralDesiredCaps;

namespace AppiumClientMobile.test.Motivist.Hybrid
{
    [TestFixture, Order(0)]
    public class OtpActivity
    {
        // ReSharper disable once UnusedMember.Global
        private protected TestContext TestContext { get; set; }

        [OneTimeSetUp]
        public void BeforeAll()
        {
            // ReSharper disable once ObjectCreationAsStatement
            new DriverWithParams(mobilePlatform: AppiumMobilePlatform,0);
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
        public void CheckAbilityToEnterNumberScreen()
        {
            // LoginPhoneNumber Click
            DriverWithParams.SendElementByAccessibilityId(
                ComMotivistDevelopment_OtpPage_LoginPhoneNumber,
                "Click",
                null);
            // LoginPhoneNumber SendKeys
            DriverWithParams.SendElementByAccessibilityId(
                ComMotivistDevelopment_OtpPage_LoginPhoneNumber,
                "SendKeys",
                ComMotivistDevelopment_CheckAbilityToEnterNumberScreen_EnteredNumber);
            // LoginPhoneNumber Read
            // ReSharper disable once SuggestVarOrType_BuiltInTypes
            string loginPhoneNumberGetText =
                DriverWithParams.GetElementTextByAccessibilityId(ComMotivistDevelopment_OtpPage_LoginPhoneNumber);
            // LoginPhoneNumber Equal Value Check
            Assert.AreEqual(
                ComMotivistDevelopment_CheckAbilityToEnterNumberScreen_ExpectedNumber,
                loginPhoneNumberGetText);
            TestContext.WriteLine(ComMotivistDevelopment_Contexts_CorrectMessage);
            // LoginButton Click
            DriverWithParams.SendElementByAccessibilityId(
                ComMotivistDevelopment_OtpPage_LoginButton,
                "Click",
                null);
        }

        [Test, Order(1)]
        public void CheckAbilityToReadOtpCodeFromOtpScreen()
        {
            // OtpTextInput Read
            // ReSharper disable once SuggestVarOrType_BuiltInTypes
            string dialogMessage = DriverWithParams.GetElementTextByAccessibilityId(
                ComMotivistDevelopment_CheckAbilityToWriteOtpCodeInsideTextArea_DialogTextMessage);
            // If an error message appears instead of the otp code, check
            if (dialogMessage == ComMotivistDevelopment_OtpDialogView_ErrorMessageText)
            {
                TestContext.WriteLine(ComMotivistDevelopment_CheckAbilityToGetThreeMinutesError_WaitMessage);
            }
            // OtpDialog Close
            DriverWithParams.SendElementByAccessibilityId(
                ComMotivistDevelopment_CheckFromMessageDialog_DialogNegativeButton,
                "Click", 
                null);
            
            // OtpField Write
            DriverWithParams.SendElementByAccessibilityId(
                ComMotivistDevelopment_CheckAbilityToOtpEnterOtpCodeScreen_OtpEditText,
                "SendKeys",
                dialogMessage);
            // LoginOtpVerify Click
            DriverWithParams.SendElementByAccessibilityId(
                ComMotivistDevelopment_CheckAbilityToOtpEnterOtpCodeScreen_LoginOtpVerify,
                "Click",
                null);
            TestContext.WriteLine(ComMotivistDevelopment_Contexts_CorrectLoginMessage);
        }
    }
}