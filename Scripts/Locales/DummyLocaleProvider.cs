namespace Scripts.Locales
{
    public class DummyLocaleProvider : ILocaleProvider
    {
        public string GetLanguageShort()
        {
            return "en";
        }

        public string GetLanguageLong()
        {
            return "english";
        }

        public string GetCountryShort()
        {
            return "US";
        }

        public string GetCountryLong()
        {
            return "United States";
        }
    }
}