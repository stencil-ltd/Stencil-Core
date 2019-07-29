using UnityEngine;

namespace Prefs
{
    public class PrefStrategyBool : IPrefStrategy
    {
        public object GetValue(string key, object defaultValue)
        {
            return PlayerPrefs.GetInt(key, (bool) defaultValue ? 1 : 0) == 1;
        }

        public void SetValue(string key, object value)
        {
            PlayerPrefs.SetInt(key, (bool) value ? 1 : 0);
        }
    }
}