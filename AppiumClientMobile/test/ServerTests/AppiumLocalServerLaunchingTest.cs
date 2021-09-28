using AppiumClientMobile.Properties;
using AppiumClientMobile.Service.Exceptions;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.Service;
using OpenQA.Selenium.Appium.Service.Options;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;

namespace AppiumClientMobile.test.ServerTests
{
    [TestFixture]
    public class AppiumLocalServerLaunchingTest
    {
        private readonly string _pathToCustomAppium;
        private string _testIp;

        public AppiumLocalServerLaunchingTest(string pathToCustomAppium)
        {
            _pathToCustomAppium = pathToCustomAppium;
        }

        [OneTimeSetUp]
        public void BeforeAll()
        {
            var isWindows = Platform.CurrentPlatform.IsPlatformType(PlatformType.Windows);
            var isMacOs = Platform.CurrentPlatform.IsPlatformType(PlatformType.Mac);
            var isLinux = Platform.CurrentPlatform.IsPlatformType(PlatformType.Linux);

            IPHostEntry host;
            var hostName = Dns.GetHostName();
            host = Dns.GetHostEntry(hostName);
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily.ToString() == "InterNetwork")
                {
                    _testIp = ip.ToString();
                    break;
                }
            }
            Console.WriteLine(Resources.AppiumLocalServerLaunchingTest_BeforeAll_Server_Test_IP__ + _testIp);
        }

        [Test]
        public void CheckAbilityToBuildDefaultService()
        {
            var service = AppiumLocalService.BuildDefaultService();

            try
            {
                service.Start();
                Assert.AreEqual(true, service.IsRunning);
            }
            finally
            {
                service.Dispose();
            }
        }

        [Test]
        public void CheckAbilityToLogServiceOutput()
        {
            var service = AppiumLocalService.BuildDefaultService();
            var lines = new List<string>();

            DataReceivedEventHandler p = (sender, e) => { lines.Add(e.Data); Console.Out.WriteLine(e.Data); };
            service.OutputDataReceived += p;

            try
            {
                service.Start();
                Assert.AreEqual(true, service.IsRunning);
            }
            finally
            {
                service.Dispose();
            }

            Assert.IsNotEmpty(lines);
        }

        [Test]
        public void CheckAbilityToBuildServiceUsingNodeDefinedInProperties()
        {
            AppiumLocalService service = null;

            try
            {
                var definedNode = _pathToCustomAppium;
                Environment.SetEnvironmentVariable(AppiumServiceConstants.AppiumBinaryPath, definedNode);
                service = AppiumLocalService.BuildDefaultService();
                service.Start();
                Assert.AreEqual(true, service.IsRunning);
            }
            finally
            {
                service?.Dispose();
                Environment.SetEnvironmentVariable(AppiumServiceConstants.AppiumBinaryPath, string.Empty);
            }
        }

        [Test]
        public void CheckAbilityToBuildServiceUsingNodeDefinedExplicitly()
        {
            AppiumLocalService service = null;

            try
            {
                service = new AppiumServiceBuilder().WithAppiumJS(new FileInfo(_pathToCustomAppium)).Build();
                service.Start();
                Assert.AreEqual(true, service.IsRunning);
            }
            finally
            {
                service?.Dispose();
            }
        }

        [Test]
        public void CheckAbilityToStartServiceOnAFreePort()
        {
            AppiumLocalService service = null;

            try
            {
                service = new AppiumServiceBuilder().UsingAnyFreePort().Build();
                service.Start();
                Assert.AreEqual(true, service.IsRunning);
            }
            finally
            {
                service?.Dispose();
            }
        }

        [Test]
        public void CheckStartingOfAServiceWithNonLocalHostIp()
        {
            var service = new AppiumServiceBuilder().WithIPAddress(_testIp).UsingPort(4000).Build();

            try
            {
                service.Start();
                Assert.IsTrue(service.IsRunning);
            }
            finally
            {
                service.Dispose();
            }
        }

        [Test]
        public void CheckAbilityToStartServiceUsingFlags()
        {
            AppiumLocalService service = null;

            var args = new OptionCollector().AddArguments(GeneralOptionList.CallbackAddress(_testIp))
                .AddArguments(GeneralOptionList.OverrideSession());

            try
            {
                service = new AppiumServiceBuilder().WithArguments(args).Build();
                service.Start();
                Assert.IsTrue(service.IsRunning);
            }
            finally
            {
                service?.Dispose();
            }

        }

        [Test]
        public void CheckAbilityToStartServiceUsingCapabilities()
        {
            var capabilities = new AppiumOptions();
            capabilities.AddAdditionalCapability(MobileCapabilityType.PlatformName, "Android");
            capabilities.AddAdditionalCapability(MobileCapabilityType.FullReset, true);
            capabilities.AddAdditionalCapability(MobileCapabilityType.NewCommandTimeout, 60);
            capabilities.AddAdditionalCapability(AndroidMobileCapabilityType.AppPackage, "com.motivist.development");
            // React Native olduğu için iki aktivite üzerinde olmasından hepsini dahil ediyoruz.
            capabilities.AddAdditionalCapability(AndroidMobileCapabilityType.AppActivity, "*");

            var args = new OptionCollector().AddCapabilities(capabilities);
            AppiumLocalService service = null;

            try
            {
                service = new AppiumServiceBuilder().WithArguments(args).Build();
                service.Start();
                Assert.IsTrue(service.IsRunning);
            }
            finally
            {
                service?.Dispose();
            }
        }

        [Test]
        public void CheckAbilityToStartServiceUsingCapabilitiesAndFlags()
        {
            var capabilities = new AppiumOptions();
            capabilities.AddAdditionalCapability(MobileCapabilityType.PlatformName, "Android");
            capabilities.AddAdditionalCapability(MobileCapabilityType.FullReset, true);
            capabilities.AddAdditionalCapability(MobileCapabilityType.NewCommandTimeout, 60);
            capabilities.AddAdditionalCapability(AndroidMobileCapabilityType.AppPackage, "com.motivist.development");
            // React Native olduğu için iki aktivite üzerinde olmasından hepsini dahil ediyoruz.
            capabilities.AddAdditionalCapability(AndroidMobileCapabilityType.AppActivity, "*");

            var args = new OptionCollector().AddCapabilities(capabilities)
                .AddArguments(GeneralOptionList.CallbackAddress(_testIp))
                .AddArguments(GeneralOptionList.OverrideSession());
            AppiumLocalService service = null;

            try
            {
                service = new AppiumServiceBuilder().WithArguments(args).Build();
                service.Start();
                Assert.IsTrue(service.IsRunning);
            }
            finally
            {
                service?.Dispose();
            }
        }

        [Test]
        public void CheckAbilityToShutDownService()
        {
            var service = AppiumLocalService.BuildDefaultService();
            service.Start();
            service.Dispose();
            Assert.IsTrue(!service.IsRunning);
        }

        [Test]
        public void CheckAbilityToStartAndShutDownServices()
        {
            var service1 = new AppiumServiceBuilder().UsingAnyFreePort().Build();
            var service2 = new AppiumServiceBuilder().UsingAnyFreePort().Build();
            var service3 = new AppiumServiceBuilder().UsingAnyFreePort().Build();
            var service4 = new AppiumServiceBuilder().UsingAnyFreePort().Build();
            var service5 = new AppiumServiceBuilder().UsingAnyFreePort().Build();

            service1.Start();
            service2.Start();
            service3.Start();
            service4.Start();
            service5.Start();
            service1.Dispose();
            Thread.Sleep(1000);
            service2.Dispose();
            Thread.Sleep(1000);
            service3.Dispose();
            Thread.Sleep(1000);
            service4.Dispose();
            Thread.Sleep(1000);
            service5.Dispose();

            Assert.IsTrue(!service1.IsRunning);
            Assert.IsTrue(!service2.IsRunning);
            Assert.IsTrue(!service3.IsRunning);
            Assert.IsTrue(!service4.IsRunning);
            Assert.IsTrue(!service5.IsRunning);
        }

        [Test]
        public void CheckTheAbilityToDefineTheDesiredLogFile()
        {
            var log = new FileInfo("Log.txt");
            var service = new AppiumServiceBuilder().WithLogFile(log).Build();

            try
            {
                service.Start();
                Assert.IsTrue(log.Exists);
                Assert.IsTrue(log.Length > 0); // Appium tebrik mesajı atacakmış dendi.
            }
            finally
            {
                service.Dispose();
                if (log.Exists)
                {
                    File.Delete(log.FullName);
                }
                service.Dispose();
            }
        }

        [Test]
        public void CheckAbilityToSetNodeArguments()
        {
            var service = new AppiumServiceBuilder()
                .WithStartUpTimeOut(TimeSpan.FromMilliseconds(500)) //Appium başlangıcının başarısız olmasını bekliyoruz, bu nedenle hızlı bir şekilde başarısız olsun.
                .WithNodeArguments("--version") // Sürümünü göstersin.
                .Build();
            var nodeOutput = new StringBuilder();

            try
            {
                DataReceivedEventHandler p = (o, args) => nodeOutput.AppendLine(args.Data);
                service.OutputDataReceived += p;
                service.Start();
            }
            catch (AppiumServerHasNotBeenStartedLocallyException)
            {
                // To Do
                throw;
            }
            finally
            {
                service.Dispose();
            }

            Assert.That(nodeOutput.ToString(), Does.Match(@"v\d+\.\d+\.\d+"));
        }

        [Test]
        public void AttemptingToSetNodeArgumentsToNullThrowsException()
        {
            var serviceBuilder = new AppiumServiceBuilder();
            string[] nullArray = null;
            Assert.Throws<ArgumentNullException>(() => serviceBuilder.WithNodeArguments(nullArray));
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("\n")]
        [TestCase("\t")]
        public void AddingInvalidNodeArgumentThrowsException(string argument)
        {
            var serviceBuilder = new AppiumServiceBuilder();
            Assert.Throws<ArgumentException>(() => serviceBuilder.WithNodeArguments(argument));
        }
    }
}
