using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;

namespace AppiumClientMobile.helpers
{
    public class Filters
    {
        public static IWebElement FirstWithName<TW>(IEnumerable<TW> els, string name) where TW : IWebElement
        {
            foreach (var t in els)
                if (t.GetAttribute("name") == name)
                    return t;

            return null;
        }

        public static IList<IWebElement> FilterWithName<TW>(IEnumerable<TW> els, string name) where TW : IWebElement
        {
            return els.Where(t => t.GetAttribute("name") == name).Cast<IWebElement>().ToList();
        }

        public static IList<IWebElement> FilterDisplayed<TW>(IList<TW> els) where TW : IWebElement
        {
            return (from t in els let el = t where t.Displayed select t).Cast<IWebElement>().ToList();
        }
    }
}
