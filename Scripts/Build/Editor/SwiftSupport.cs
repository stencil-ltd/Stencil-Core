using System.IO;
using System.Linq;
using JetBrains.Annotations;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEditor.iOS.Xcode;
using UnityEngine;

namespace Scripts.Build.Editor
{
    public class SwiftSupport
    {
        public static bool shouldRun = false;
        public static string swiftVersion = "5.0";
        
        // From https://github.com/googlesamples/unity-jar-resolver/blob/master/source/IOSResolver/src/IOSResolver.cs#L1404
        // In theory, it looks like taking #4 will execute us right between #4 and #5, which is what we want.
        // Hopefully this remains constant.
        private const int BUILD_ORDER_GEN_PODFILE = 4;
        private const int BUILD_ORDER_INSTALL_PODS = 5;

        [PostProcessBuild(BUILD_ORDER_GEN_PODFILE), UsedImplicitly]
        public static void OnPostProcess(BuildTarget target, string path)
        {
#if UNITY_IOS
            if (shouldRun && target == BuildTarget.iOS)
            {
                // XCProj
                string projPath = PBXProject.GetPBXProjectPath(path);

                PBXProject proj = new PBXProject();
                proj.ReadFromString(File.ReadAllText(projPath));

                string targetName = PBXProject.GetUnityTargetName();
                string projectTarget = proj.TargetGuidByName(targetName);
                
                proj.AddBuildProperty(projectTarget, "SWIFT_VERSION", swiftVersion);
                File.WriteAllText(projPath, proj.WriteToString());
                
                // Podfile
                var podfile = $"{path}/Podfile";
                if (!File.Exists(podfile))
                {
                    Debug.LogError($"No podfile found at {podfile}");
                    return;
                }
                Debug.Log($"Podfile found at {podfile}. Adding use_framworks!");
                var lines = File.ReadAllLines(podfile).ToList();
                lines.Insert(1, "use_frameworks!");
                File.WriteAllLines(podfile, lines);
            }
#endif
        }
    }
}