using Dev;
using UnityEngine;

namespace Util
{
    public struct PlatformValue<T>
    {
        public static implicit operator T(PlatformValue<T> plat) => plat.Value;
        
        public T Value { get; private set; }
        public bool IsDeveloper => Developers.Enabled;

        public T Base { get; private set; }
        public T Android { get; private set; }
        public T Ios { get; private set; }
        public T Editor { get; private set; }

        public PlatformValue(T value)
        {
            Value = value;
            Base = value;
            Android = default(T);
            Ios = default(T);
            Editor = default(T);
        }

        public PlatformValue<T> WithAndroid(T value, T developer) => WithAndroid(IsDeveloper ? developer : value);
        public PlatformValue<T> WithAndroid(T value)
        {
            Android = value;
            if (Application.platform == RuntimePlatform.Android)
                Value =  value;
            return this;
        }

        public PlatformValue<T> WithIos(T value, T developer) => WithIos(IsDeveloper ? developer : value);
        public PlatformValue<T> WithIos(T value)
        {
            Ios = value;
            if (Application.platform == RuntimePlatform.IPhonePlayer)
                Value = value;
            return this;
        }

        public PlatformValue<T> WithEditor(T value, T developer) => WithEditor(IsDeveloper ? developer : value);
        public PlatformValue<T> WithEditor(T value)
        {
            Editor = value;
            if (Application.isEditor)
                Value = value;
            return this;
        }
    }
}