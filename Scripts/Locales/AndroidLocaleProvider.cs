#if UNITY_ANDROID
using UnityEngine;

namespace Scripts.Locales
{
    /**
     * https://forum.unity.com/threads/cultureinfo-currentculture-always-returning-invariant-language-invariant-country.554941/#post-3687037
     */
    public class AndroidLocaleProvider : ILocaleProvider
    {
        private AndroidJavaClass cls;
        private AndroidJavaObject locale;

        public AndroidLocaleProvider()
        {
            cls = new AndroidJavaClass("java.util.Locale");
            locale = cls.CallStatic<AndroidJavaObject>("getDefault");
        }

        public string GetLanguageShort()
        {
            return locale.Call<string>("getLanguage");
        }

        public string GetLanguageLong()
        {
            return locale.Call<string>("getDisplayLanguage");
        }

        public string GetCountryShort()
        {
            return locale.Call<string>("getCountry");
        }

        public string GetCountryLong()
        {
            return locale.Call<string>("getDisplayCountry");
        }
    }
}
#endif