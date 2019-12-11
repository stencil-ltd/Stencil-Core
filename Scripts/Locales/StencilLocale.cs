using UnityEngine;
using Util;

namespace Scripts.Locales
{
    public static class StencilLocale
    {
        private static bool _init;
        private static ILocaleProvider _provider = new DummyLocaleProvider();
        
        public static void Init()
        {
            if (_init) return;
            _init = true;
            Debug.Log($"Initializing StencilLocale...");
#if !UNITY_EDITOR
                #if UNITY_ANDROID
                    _provider = new AndroidLocaleProvider();
                #elif UNITY_IOS
                    _provider = new IosLocaleProvider();
                #endif
#endif
            Debug.Log($"StencilLocale Initialized!");
        }

        public static string GetLocaleString()
        {
            return $"{GetLanguageShort()}-{GetCountryShort()}";
        }
        
        public static string GetLanguageShort()
        {
            return _provider.GetLanguageShort();
        }

        public static string GetLanguageLong()
        {
            return _provider.GetLanguageLong();
        }

        public static string GetCountryShort()
        {
            return _provider.GetCountryShort();
        }

        public static string GetCountryLong()
        {
            return _provider.GetCountryLong();
        }
    }
}