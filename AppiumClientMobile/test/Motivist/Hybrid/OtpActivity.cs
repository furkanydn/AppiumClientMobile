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
        private protected TestContext TestContext { get; set; }

        [OneTimeSetUp]
        // ReSharper disable once ObjectCreationAsStatement
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
            var dMessage = ActionByElement(Commands.Text, FindMethod.ByAccessibilityId,
                ComMotivistDevelopment_CheckAbilityToWriteOtpCodeInsideTextArea_DialogTextMessage);
            Assert.That(
                ActionByElement(Commands.Text, FindMethod.ByAccessibilityId,
                    ComMotivistDevelopment_CheckAbilityToWriteOtpCodeInsideTextArea_DialogTextMessage),
                Is.Not.EqualTo(ComMotivistDevelopment_OtpDialogView_ErrorMessageText));
            ActionByElement(Commands.Click, FindMethod.ByAccessibilityId,
                ComMotivistDevelopment_CheckFromMessageDialog_DialogNegativeButton);
            ActionByElement(Commands.SendKeys, FindMethod.ByAccessibilityId,
                ComMotivistDevelopment_CheckAbilityToOtpEnterOtpCodeScreen_OtpEditText, dMessage);
            ActionByElement(Commands.Click, FindMethod.ByAccessibilityId,
                ComMotivistDevelopment_CheckAbilityToOtpEnterOtpCodeScreen_LoginOtpVerify);
            TestContext.WriteLine(ComMotivistDevelopment_Contexts_CorrectLoginMessage);
        }
    }
}