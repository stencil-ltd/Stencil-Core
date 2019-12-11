namespace UnityEngine
{
    public static class StencilPermissions
    {
        private static bool _init;
        private static IPermissions _permissions = new DummyPermissions();
        
        public static void Init()
        {
            if (_init) return;
            _init = true;
            #if !UNITY_EDITOR
            #if UNITY_ANDROID
            _permissions = new AndroidPermissions();
            #elif UNITY_IOS
            _permissions = new IosPermissions();
            #endif
            #endif
        }
    }
}