using System.Collections.Generic;
using System.IO;
using AppiumClientMobile.Properties;

namespace AppiumClientMobile.helpers
{
    public class Apps
    {
        private static bool _isInited;
        private static Dictionary<string, string> _testApps;

        private static void Init()
        {
            if (_isInited) return;
            if (Env.ServerIsRemote())
            {
                _testApps = new Dictionary<string, string> {{Motivistv5, "https://inooster-my.sharepoint.com/personal/erdi_yildiz_inooster_com/Documents/Microsoft%20Teams%20Chat%20Files/Motivist-Mobile%20(1).apk"}};
            }
            else
            {
                var tempFolder = Path.GetTempPath();
                File.WriteAllBytes($"{tempFolder}/androidDemo.apk", Resources.motivistv5);
                _testApps = new Dictionary<string, string> {{Motivistv5, new FileInfo($"{Path.GetTempPath()}/motivistv5.apk").FullName}};
            }

            _isInited = true;
        }

        public static string Get(string appKey)
        {
            Init();
            return _testApps[appKey];
        }

        public static byte[] GetAppPackage()
        {
            return Resources.motivistv5;
        }

        private const string Motivistv5 = "motivistv5";
    }
}
