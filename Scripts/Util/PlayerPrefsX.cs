using System;
using UnityEngine;

namespace Util
{
    public static class PlayerPrefsX
    {
        [Obsolete]
        public static void RegisterStrategies()
        {
            // Nothing.
        }
        
        public static bool? GetBoolNullable(string key)
        {
            var intVal = PlayerPrefs.GetInt(key, -1);
            switch (intVal)
            {
                case 1:
                    return true;
                case -1:
                    return null;
                default:
                    return false;
            }
        }
        
        public static bool GetBool(string key, bool defaultValue = false)
        {
            var intVal = PlayerPrefs.GetInt(key, -1);
            switch (intVal)
            {
                case 1:
                    return true;
                case -1:
                    return defaultValue;
                default:
                    return false;
            }
        }
        
        public static void SetBoolNullable(string key, bool? value)
        {
            if (value == null)
                PlayerPrefs.DeleteKey(key);
            else
                PlayerPrefs.SetInt(key, value.Value ? 1 : 0);
        }

        public static void SetBool(string key, bool value)
        {
            PlayerPrefs.SetInt(key, value ? 1 : 0);
        }
        
        public static long GetLong(string key, long defaultValue = 0L)
        {
            var str = PlayerPrefs.GetString(key);
            return string.IsNullOrEmpty(str) ? defaultValue : long.Parse(str);
        }

        public static void SetLong(string key, long value)
        {
            PlayerPrefs.SetString(key, value.ToString());
        }

        public static DateTime? GetDateTime(string key, DateTime? defaultValue = null)
        {
            var binary = GetLong(key);
            return binary == 0 ? defaultValue : DateTime.FromBinary(binary);
        }

        public static void SetDateTime(string key, DateTime? value)
        {
            if (value.HasValue)
                SetLong(key, value.Value.ToBinary());
            else PlayerPrefs.DeleteKey(key);
        }

        public static T GetJson<T>(string key)
        {
            var str = PlayerPrefs.GetString(key);
            if (string.IsNullOrEmpty(str)) return default(T);
            return JsonUtility.FromJson<T>(str);
        }

        public static void SetJson<T>(string key, T value)
        {
            PlayerPrefs.SetString(key, JsonUtility.ToJson(value));
        }
    }
}