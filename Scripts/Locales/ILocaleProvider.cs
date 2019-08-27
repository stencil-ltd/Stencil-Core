namespace Scripts.Locales
{
    public interface ILocaleProvider
    {
        string GetLanguageShort();
        string GetLanguageLong();
        string GetCountryShort();
        string GetCountryLong();
    }
}