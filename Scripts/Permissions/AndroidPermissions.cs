#if UNITY_ANDROID

using System.Collections.Generic;
using Plugins.Collections;
using UnityEngine;

namespace Stencil.Permissions
{
    public class AndroidPermissions : IPermissions
    {
        private static readonly Dictionary<Permission, string> NativeMap = new Dictionary<Permission, string>
        {
            { Permission.Camera, UnityEngine.Android.Permission.Camera },
            { Permission.Microphone, UnityEngine.Android.Permission.Microphone },
            { Permission.Contacts, "android.permission.READ_CONTACTS" },
            { Permission.Voice, "android.permission.RECORD_AUDIO" },
        };
        
        private static AndroidJavaObject GetCurrentActivity() {
            return new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");
        }

        public bool HasPermission(Permission permission)
        {
            var str = NativeMap.GetValueOrDefault(permission);
            if (str != null)
                return UnityEngine.Android.Permission.HasUserAuthorizedPermission(str);
            return true;
        }

        public void RequestPermission(Permission permission)
        {
            if (HasPermission(permission)) return;
            var str = NativeMap.GetValueOrDefault(permission);
            if (str != null) UnityEngine.Android.Permission.RequestUserPermission(str);
        }
    }
}

#endif