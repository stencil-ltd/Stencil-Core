using UnityEngine;

namespace Prefs
{
    public class PrefStrategyString : IPrefStrategy
    {
        public object GetValue(string key, object defaultValue)
        {
            return PlayerPrefs.GetString(key, (string) defaultValue);
        }

        public void SetValue(string key, object value)
        {
            PlayerPrefs.SetString(key, (string) value);
        }
    }
}