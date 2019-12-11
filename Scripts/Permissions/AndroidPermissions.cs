using System;
using System.Collections.Generic;
using Plugins.Collections;

namespace UnityEngine
{
    public class AndroidPermissions : IPermissions
    {
        private static readonly Dictionary<Permission, string> NativeMap = new Dictionary<Permission, string>
        {
            { Permission.Camera, Android.Permission.Camera },
            { Permission.Microphone, Android.Permission.Microphone },
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
                return Android.Permission.HasUserAuthorizedPermission(str);
            return true;
        }

        public void RequestPermission(Permission permission)
        {
            if (HasPermission(permission)) return;
            var str = NativeMap.GetValueOrDefault(permission);
            if (str != null) Android.Permission.RequestUserPermission(str);
        }
    }
}