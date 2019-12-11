using System.Collections.Generic;
using Plugins.Collections;
using Scripts.Prefs;

namespace UnityEngine
{
    public class DummyPermissions : IPermissions
    {
        public bool HasPermission(Permission permission) => 
            StencilPrefs.Default.GetBool($"stencil_permissions_{permission}");

        public void RequestPermission(Permission permission)
        {
            if (HasPermission(permission)) return;
            StencilPrefs.Default.SetBool($"stencil_permissions_{permission}", true).Save();
        }
    }
}