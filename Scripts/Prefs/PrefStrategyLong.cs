using Util;

namespace Prefs
{
    public class PrefStrategyLong : IPrefStrategy
    {
        public object GetValue(string key, object defaultValue)
        {
            return PlayerPrefsX.GetLong(key, (long) defaultValue);
        }

        public void SetValue(string key, object value)
        {
            PlayerPrefsX.SetLong(key, (long) value);
        }
    }
}