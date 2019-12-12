using System.Runtime.InteropServices;

namespace Stencil.Permissions
{
    public class IosPermissions : IPermissions
    {
        [DllImport("__Internal")]
        private static extern bool __IosHasPermission(string permission);
        
        [DllImport("__Internal")]
        private static extern bool __IosRequestPermission(string permission);
        
        public bool HasPermission(Permission permission)
        {
            return __IosHasPermission(permission.ToString());
        }

        public void RequestPermission(Permission permission)
        {
            __IosRequestPermission(permission.ToString());
        }
    }
}