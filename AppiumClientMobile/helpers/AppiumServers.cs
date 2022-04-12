using System;
using System.Diagnostics;
using System.IO;
using AppiumClientMobile.helpers;
using AppiumClientMobile.Properties;
using OpenQA.Selenium.Appium.Service;

namespace AppiumClientMobile.Helpers
{
    internal static class AppiumServers
    {
        private static AppiumLocalService _localService;
        private static Uri _remoteAppiumServerUri;

        public static Uri LocalServiceUri
        {
            get
            {
                switch (_localService)
                {
                    case null:
                    {
                        var builder =
                            new AppiumServiceBuilder()
                                .WithLogFile(new FileInfo(Path.GetTempPath() + "Log.txt"));
                        _localService = builder.Build();
                        break;
                    }
                }
                if (_localService.IsRunning) return _localService.ServiceUrl;
                _localService.Start();

                return _localService.ServiceUrl;
            }
            set => throw new NotImplementedException();
        }

        public static Uri RemoteServerUri
        {
            get
            {
                if (_remoteAppiumServerUri != null)
                    return _remoteAppiumServerUri;
                _remoteAppiumServerUri = new Uri(Env.GetEnvVar("remoteAppiumServerUri"));

                return _remoteAppiumServerUri;
            }
            set => throw new NotImplementedException();
        }

        public static void StopLocalService()
        {
            if (!(_localService is {IsRunning: true})) return;
            _localService.Dispose();
            _localService = null;
        }
        public static Uri StartLocalService()
        {
            var localServerUri = new Uri(Resources.Helpers_AppiumServers_ServerAddress);
            return localServerUri;
        }
        public static void RunAppiumServer()
        {
            var processStartInfo = new ProcessStartInfo
            {
                UseShellExecute = false,
                WorkingDirectory = "/Users/furkanaydin/Projects/AppiumClientMobile/AppiumClientMobile/Resources/Scripts/appiumStart.sh",
                FileName = "sh",
                RedirectStandardOutput = true,
            };
            var cmd = Process.Start(processStartInfo);
            cmd?.WaitForExit();
        }
    }
}
