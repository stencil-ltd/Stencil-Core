using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Stencil.Util;
using UnityEngine;
using Util;

namespace Scripts.Prefs
{
    [Serializable]
    public class StencilPrefs
    {
        public static StencilPrefs Default = new StencilPrefs();
        
        public PrefConfig config;
        public StencilPrefs(PrefConfig config)
        {
            this.config = config;
        }

        public StencilPrefs()
        {}

        #region PlayerPrefs

        public bool HasKey(string key)
        {
            return PlayerPrefs.HasKey(config.Process(key));
        }

        public StencilPrefs DeleteKey(string key)
        {
            PlayerPrefs.DeleteKey(config.Process(key));
            return this;
        }

        public StencilPrefs Save()
        {
            PlayerPrefs.Save();
            return this;
        }

        public int GetInt(string key, int defaultValue = 0) => PlayerPrefs.GetInt(config.Process(key), defaultValue);
        public StencilPrefs SetInt(string key, int value)
        {
            PlayerPrefs.SetInt(config.Process(key), value);
            return this;
        }
        
        public long GetLong(string key, long defaultValue = 0L) => PlayerPrefsX.GetLong(config.Process(key), defaultValue);
        public StencilPrefs SetLong(string key, long value)
        {
            PlayerPrefsX.SetLong(config.Process(key), value);
            return this;
        }
        
        public string GetString(string key, string defaultValue = null) => PlayerPrefs.GetString(config.Process(key), defaultValue);
        public StencilPrefs SetString(string key, string value)
        {
            PlayerPrefs.SetString(config.Process(key), value);
            return this;
        }
        
        public float GetFloat(string key, float defaultValue = 0f) => PlayerPrefs.GetFloat(config.Process(key), defaultValue);
        public StencilPrefs SetFloat(string key, float value)
        {
            PlayerPrefs.SetFloat(config.Process(key), value);
            return this;
        }
        
        public bool GetBool(string key, bool defaultValue = false) => PlayerPrefsX.GetBool(config.Process(key), defaultValue);
        public StencilPrefs SetBool(string key, bool value)
        {
            PlayerPrefsX.SetBool(config.Process(key), value);
            return this;
        }
        
        public DateTime? GetDateTime(string key, DateTime? defaultValue = null) => PlayerPrefsX.GetDateTime(config.Process(key), defaultValue);
        public StencilPrefs SetDateTime(string key, DateTime? value)
        {
            PlayerPrefsX.SetDateTime(config.Process(key), value);
            return this;
        }

        public Dictionary<K,V> GetDictionary<K,V>(string key, [CanBeNull] Dictionary<K,V> defaultValue = null) => PlayerPrefsX.GetDictionary(config.Process(key), defaultValue);

        public StencilPrefs SetDictionary<K, V>(string key, [CanBeNull] Dictionary<K, V> value)
        {
            PlayerPrefsX.SetDictionary(config.Process(key), value);
            return this;
        }

        #endregion
    }
}