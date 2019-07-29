using System;
using JetBrains.Annotations;

namespace Scripts.Prefs
{
    [Serializable]
    public struct PrefConfig
    {
        [CanBeNull] 
        public string key;
            
        public string Process(string key)
        {
            if (string.IsNullOrEmpty(this.key)) return key;
            return $"{key}__{this.key}";
        }
    }
}