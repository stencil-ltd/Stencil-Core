namespace UnityEngine
{
    public interface IPermissions
    {
        bool HasPermission(Permission permission);
        void RequestPermission(Permission permission);
    }
}