using System.Collections.Generic;
using Plugins.Collections;

namespace UnityEngine
{
    public class DummyPermissions : IPermissions
    {
        private Dictionary<Permission, bool> _perms = new Dictionary<Permission, bool>();
        
        public bool HasPermission(Permission permission) => _perms.GetValueOrDefault(permission);
        public void RequestPermission(Permission permission)
        {
            if (HasPermission(permission)) return;
            _perms[permission] = true;
        }
    }
}