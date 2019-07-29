using UnityEngine;

namespace Prefs
{
    public class PrefStrategyInt : IPrefStrategy
    {
        public object GetValue(string key, object defaultValue)
        {
            return PlayerPrefs.GetInt(key, (int) defaultValue);
        }

        public void SetValue(string key, object value)
        {
            PlayerPrefs.SetInt(key, (int) value);
        }
    }
}