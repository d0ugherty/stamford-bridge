using UnityEditor;

public class BuildScript
{
    // Define a custom build method
    public static void BuildWindows()
    {
        // Set the build target to Windows
        BuildTarget buildTarget = BuildTarget.StandaloneWindows64;

        // Specify the output path for the build
        string outputPath = "Build/WindowsBuild";

        // Build the game
        BuildPipeline.BuildPlayer(GetScenePaths(), outputPath, buildTarget, BuildOptions.None);
    }

    // Helper method to get the list of scene paths to build
    private static string[] GetScenePaths()
    {
        // Here, you can return an array of scene paths that you want to include in the build.
        // For example:
        return new string[] { "Assets/Scenes/MainMenu.unity", "Assets/Scenes/BridgeScene.unity" };
    }
}