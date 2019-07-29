namespace Prefs
{
    public interface IPrefStrategy
    {
        object GetValue(string key, object defaultValue);
        void SetValue(string key, object value);
    }
}