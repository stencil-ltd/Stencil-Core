#if UNITY_IOS

using System.Runtime.InteropServices;

namespace Scripts.Locales
{
    public class IosLocaleProvider : ILocaleProvider
    {
        [DllImport("__Internal")]
        private static extern string __IosGetLanguageShort();
        
        [DllImport("__Internal")]
        private static extern string __IosGetLanguageLong();
        
        [DllImport("__Internal")]
        private static extern string __IosGetCountryShort();
        
        [DllImport("__Internal")]
        private static extern string __IosGetCountryLong();
        
        public string GetLanguageShort()
        {
            return __IosGetLanguageShort();
        }

        public string GetLanguageLong()
        {
            return __IosGetLanguageLong();
        }

        public string GetCountryShort()
        {
            return __IosGetCountryShort();
        }

        public string GetCountryLong()
        {
            return __IosGetCountryLong();
        }
    }
}

#endif