#if DISABLE_BITCODE
using JetBrains.Annotations;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEditor.iOS.Xcode;

public class DisableBitcode
{
    [PostProcessBuild(1000), UsedImplicitly]
    public static void Execute(BuildTarget target, string path)
    {
        if (target != BuildTarget.iOS) return;
        var projectPath = path + "/Unity-iPhone.xcodeproj/project.pbxproj";
        var pbxProject = new PBXProject();
        pbxProject.ReadFromFile(projectPath);
        var t = pbxProject.TargetGuidByName("Unity-iPhone");            
        pbxProject.SetBuildProperty(t, "ENABLE_BITCODE", "NO");
        pbxProject.WriteToFile (projectPath);
    }
}
#endif