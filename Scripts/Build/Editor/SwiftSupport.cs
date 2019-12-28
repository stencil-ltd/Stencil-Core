#if STENCIL_SWIFT

using System.IO;
using System.Linq;
using JetBrains.Annotations;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEditor.iOS.Xcode;
using UnityEngine;

using Google;

namespace Scripts.Build.Editor
{
    public class SwiftSupport
    {
        public static string swiftVersion = "5.0";
        
        // From https://github.com/googlesamples/unity-jar-resolver/blob/master/source/IOSResolver/src/IOSResolver.cs#L1404
        private const int BUILD_ORDER_INSTALL_PODS = 5;
        
        [PostProcessBuild(BUILD_ORDER_INSTALL_PODS+1), UsedImplicitly]
        public static void OnPostProcess(BuildTarget target, string path)
        {
            if (target != BuildTarget.iOS) return;
            // XCProj
            string projPath = PBXProject.GetPBXProjectPath(path);

            PBXProject proj = new PBXProject();
            proj.ReadFromString(File.ReadAllText(projPath));

            string targetName = "Unity-iPhone";
            string projectTarget = proj.TargetGuidByName(targetName);
                
            proj.AddBuildProperty(projectTarget, "SWIFT_OBJC_BRIDGING_HEADER", "Libraries/Platform/iOS/Unity-iPhone-Bridging-Header.h");
            proj.AddBuildProperty(projectTarget, "SWIFT_VERSION", swiftVersion);
            File.WriteAllText(projPath, proj.WriteToString());
                
            // Podfile
            var podfile = $"{path}/Podfile";
            if (!File.Exists(podfile))
            {
                Debug.LogError($"No podfile found at {podfile}. Creating Empty one.");
                return;
            }
                
            Debug.Log($"Podfile found at {podfile}. Adding use_frameworks!");
            var lines = File.ReadAllLines(podfile).ToList();
            lines.Insert(0, "use_frameworks!");
            File.WriteAllLines(podfile, lines);
                
            // Unfortunately we have to re-run the install. This sucks.
            IOSResolver.OnPostProcessInstallPods(target, path);

        }
    }
}

#endif