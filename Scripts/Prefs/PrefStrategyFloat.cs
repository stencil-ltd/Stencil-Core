using UnityEngine;

namespace Prefs
{
    public class PrefStrategyFloat : IPrefStrategy
    {
        public object GetValue(string key, object defaultValue)
        {
            return PlayerPrefs.GetFloat(key, (float) defaultValue);
        }

        public void SetValue(string key, object value)
        {
            PlayerPrefs.SetFloat(key, (float) value);
        }
    }
}