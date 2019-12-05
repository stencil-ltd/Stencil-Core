using System.Globalization;
using UnityEngine;

namespace Scripts.Locales
{
    public class DummyLocaleProvider : ILocaleProvider
    {
        public string GetLanguageShort()
        {
            return CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
        }

        public string GetLanguageLong()
        {
            return Application.systemLanguage.ToString();
        }

        public string GetCountryShort()
        {
            return RegionInfo.CurrentRegion.TwoLetterISORegionName;
        }

        public string GetCountryLong()
        {
            return RegionInfo.CurrentRegion.NativeName;
        }
    }
}