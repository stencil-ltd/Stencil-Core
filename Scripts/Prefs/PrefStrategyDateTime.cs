using System;
using Util;

namespace Prefs
{
    public class PrefStrategyDateTime : IPrefStrategy
    {
        public object GetValue(string key, object defaultValue)
        {
            return PlayerPrefsX.GetDateTime(key, (DateTime?) defaultValue);
        }

        public void SetValue(string key, object value)
        {
            PlayerPrefsX.SetDateTime(key, (DateTime?) value);
        }
    }
}