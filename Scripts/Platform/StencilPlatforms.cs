using UnityEngine;

namespace Util
{
    public static class StencilPlatforms
    {
        public static bool IsAndroid(bool allowEditor = true) => (allowEditor || !Application.isEditor) && Application.platform == RuntimePlatform.Android;
        public static bool IsIos(bool allowEditor = true) => (allowEditor || !Application.isEditor) && Application.platform == RuntimePlatform.IPhonePlayer;
    }
}