using UnityEditor;
using System.Collections.Generic;
using System.IO;

public class BuildScript
{
    [MenuItem("Build/Build Android APK")]
    public static void PerformAndroidBuild()
    {
        string buildPath = "Builds/Android";
        if (!Directory.Exists(buildPath))
        {
            Directory.CreateDirectory(buildPath);
        }

        string[] scenes = GetScenes();
        string buildFile = Path.Combine(buildPath, "PolyRaid_Extra.apk");

        BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
        buildPlayerOptions.scenes = scenes;
        buildPlayerOptions.locationPathName = buildFile;
        buildPlayerOptions.target = BuildTarget.Android;
        buildPlayerOptions.options = BuildOptions.None;

        // Set Android Build Settings
        EditorUserBuildSettings.buildAppBundle = false; // We want APK, not AAB
        EditorUserBuildSettings.androidBuildSystem = AndroidBuildSystem.Gradle;

        BuildReport report = BuildPipeline.BuildPlayer(buildPlayerOptions);
        BuildSummary summary = report.summary;

        if (summary.result == BuildResult.Succeeded)
        {
            UnityEngine.Debug.Log("Build succeeded: " + summary.totalSize + " bytes");
        }

        if (summary.result == BuildResult.Failed)
        {
            UnityEngine.Debug.Log("Build failed");
        }
    }

    private static string[] GetScenes()
    {
        List<string> scenes = new List<string>();
        foreach (EditorBuildSettingsScene scene in EditorBuildSettings.scenes)
        {
            if (scene.enabled)
            {
                scenes.Add(scene.path);
            }
        }
        return scenes.ToArray();
    }
}
