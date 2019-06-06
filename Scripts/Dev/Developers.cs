using UnityEngine;

namespace Dev
{
    public static class Developers
    {
        public static bool Enabled => Application.isEditor || Debug.isDebugBuild;
    }
}