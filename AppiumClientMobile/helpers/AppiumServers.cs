﻿using OpenQA.Selenium.Appium.Service;
using System;
using System.IO;
using System.Diagnostics;
using AppiumClientMobile.helpers;

namespace AppiumClientMobile.Helpers
{
    public class AppiumServers
    {
        private static AppiumLocalService _localService;
        private static Uri _remoteAppiumServerUri;

        public static Uri LocalServiceUri
        {
            get
            {
                if(_localService == null)
                {
                    var builder =
                        new AppiumServiceBuilder()
                        .WithLogFile(new FileInfo(Path.GetTempPath() + "Log.txt"));

                    _localService = builder.Build();
                }
                if (!_localService.IsRunning)
                {
                    _localService.Start();
                }

                return _localService.ServiceUrl;
            }
        }

        public static Uri RemoteServerUri
        {
            get
            {
                if (_remoteAppiumServerUri == null)
                {
                    _remoteAppiumServerUri = new Uri(Env.GetEnvVar("remoteAppiumServerUri"));
                } else
                {
                    return _remoteAppiumServerUri;
                }

                return _remoteAppiumServerUri;
            }
        }
        public static void StopLocalService()
        {
            if (_localService != null && _localService.IsRunning)
            {
                _localService.Dispose();
                _localService = null;
            }
        }

        public static Uri StartLocalService()
        {
            var localServerUri = new Uri("http://localhost:4723/wd/hub");
            return localServerUri;
        }
    }
}
