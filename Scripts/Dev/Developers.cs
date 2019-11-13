using UnityEngine;

namespace Dev
{
    public static class Developers
    {
        public static bool? Force = null;
        public static bool Enabled => Force ?? (Application.isEditor || Debug.isDebugBuild);
    }
}