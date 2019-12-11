namespace UnityEngine
{
    public class StencilPermissions : IPermissions
    {
        private IPermissions _permissions = new DummyPermissions();

        public StencilPermissions()
        {
#if !UNITY_EDITOR
            #if UNITY_ANDROID
            _permissions = new AndroidPermissions();
            #elif UNITY_IOS
            _permissions = new IosPermissions();
            #endif
#endif
        }

        public bool HasPermission(Permission permission) => 
            _permissions.HasPermission(permission);

        public void RequestPermission(Permission permission) => 
            _permissions.RequestPermission(permission);
    }
}