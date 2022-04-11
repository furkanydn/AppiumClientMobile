using AppiumClientMobile.helpers;
using NUnit.Framework;
using static AppiumClientMobile.Properties.AccessibilityIds;
using static AppiumClientMobile.Properties.Resources;
using static AppiumClientMobile.helpers.DriverWPs;

namespace AppiumClientMobile.test.Motivist.Hybrid
{
    [TestFixture, Order(0)]
    public class OtpActivity
    {
        // ReSharper disable once UnusedMember.Global
        private protected TestContext TestContext { get; set; }

        [OneTimeSetUp]
        public void BeforeAll() => new DriverWPs(MobilePlatform.Android, MobileProject.Motivist, true);

        [Test, Order(0)]
        public void CheckAbilityToEnterNumberScreen()
        {
            ActionByElement(Commands.Click, FindMethod.ByAccessibilityId, ComMotivistDevelopment_OtpPage_LoginPhoneNumber);
            ActionByElement(Commands.SendKeys, FindMethod.ByAccessibilityId,
                ComMotivistDevelopment_OtpPage_LoginPhoneNumber,
                ComMotivistDevelopment_CheckAbilityToEnterNumberScreen_EnteredNumber);
            var numText = ActionByElement(Commands.Text, FindMethod.ByAccessibilityId, ComMotivistDevelopment_OtpPage_LoginPhoneNumber);
            Assert.That(ComMotivistDevelopment_CheckAbilityToEnterNumberScreen_ExpectedNumber,Is.EqualTo(numText));
            ActionByElement(Commands.Click, FindMethod.ByAccessibilityId, ComMotivistDevelopment_OtpPage_LoginButton);
        }

        [Test, Order(1)]
        public void CheckAbilityToReadOtpCodeFromOtpScreen()
        {
            // OtpTextInput Read
            // ReSharper disable once SuggestVarOrType_BuiltInTypes
            string dialogMessage = GetElementTextByAccessibilityId(
                ComMotivistDevelopment_CheckAbilityToWriteOtpCodeInsideTextArea_DialogTextMessage);
            // If an error message appears instead of the otp code, check
            if (dialogMessage == ComMotivistDevelopment_OtpDialogView_ErrorMessageText)
            {
                TestContext.WriteLine(ComMotivistDevelopment_CheckAbilityToGetThreeMinutesError_WaitMessage);
            }
            // OtpDialog Close
            SendElementByAccessibilityId(
                ComMotivistDevelopment_CheckFromMessageDialog_DialogNegativeButton,
                "Click", 
                null);
            
            // OtpField Write
            SendElementByAccessibilityId(
                ComMotivistDevelopment_CheckAbilityToOtpEnterOtpCodeScreen_OtpEditText,
                "SendKeys",
                dialogMessage);
            // LoginOtpVerify Click
            SendElementByAccessibilityId(
                ComMotivistDevelopment_CheckAbilityToOtpEnterOtpCodeScreen_LoginOtpVerify,
                "Click",
                null);
            TestContext.WriteLine(ComMotivistDevelopment_Contexts_CorrectLoginMessage);
        }
    }
}