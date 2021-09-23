using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


#if UNITY_EDITOR
public static class BuildTool
{
    public static string[] paths = new string[1] { "Assets/_Project/_Scenes/MainGameScene.unity" };

    [MenuItem("Tools/Build Game/Build All Windows")]
    public static void BuildAllModeWin()
    {
        BuildClientWin();
        BuildServerWin();
        BuildServerWinHeadless();
    }

    [MenuItem("Tools/Build Game/Build All OSX")]
    public static void BuildAllModeMac()
    {
        BuildClientMac();
        BuildServerMac();
        BuildServerMacHeadless();
    }

    [MenuItem("Tools/Build Game/Build Custom Windows")]
    public static void BuildDevelopmentModeWin()
    {
        var bpo1 = new BuildPlayerOptions
        {
            scenes = paths,
            locationPathName = "BuildWin/ServerCustom/ServerBuildWindows.exe",
            options = BuildOptions.Development,
            target = BuildTarget.StandaloneWindows,
        };
        var bpo2 = new BuildPlayerOptions
        {
            scenes = paths,
            locationPathName = "BuildWin/ClientCustom/ClientBuildWindows.exe",
            options = BuildOptions.Development,
            target = BuildTarget.StandaloneWindows,
        };

        BuildPipeline.BuildPlayer(bpo1);
        BuildPipeline.BuildPlayer(bpo2);
    }

    [MenuItem("Tools/Build Game/Build Client Windows")]
    public static void BuildClientWin()
    {
        var bpo = new BuildPlayerOptions
        {
            scenes = paths,
            locationPathName = "BuildWin/Client/ClientBuildWindows.exe",
            options = BuildOptions.None,
            target = BuildTarget.StandaloneWindows,
        };
        BuildPipeline.BuildPlayer(bpo);
    }


    [MenuItem("Tools/Build Game/Build Server Windows")]
    public static void BuildServerWin()
    {
        var bpo = new BuildPlayerOptions
        {
            scenes = paths,
            locationPathName = "BuildWin/Server/ServerBuildWindows.exe",
            options = BuildOptions.None,
            target = BuildTarget.StandaloneWindows,
        };
        BuildPipeline.BuildPlayer(bpo);
    }

    [MenuItem("Tools/Build Game/Build Headless Server Windows ")]
    public static void BuildServerWinHeadless()
    {
        var bpo = new BuildPlayerOptions
        {
            scenes = paths,
            locationPathName = "BuildWin/ServerHeadless/ServerBuildWindows.exe",
            options = BuildOptions.EnableHeadlessMode,
            target = BuildTarget.StandaloneWindows,
        };
        BuildPipeline.BuildPlayer(bpo);
    }

    [MenuItem("Tools/Build Game/Build Client OSX")]
    public static void BuildClientMac()
    {
        var bpo = new BuildPlayerOptions
        {
            scenes = paths,
            locationPathName = "BuildMac/Client/ClientBuild.app",
            options = BuildOptions.None,
            target = BuildTarget.StandaloneOSX,
        };
        BuildPipeline.BuildPlayer(bpo);
    }

    [MenuItem("Tools/Build Game/Build Server OSX")]
    public static void BuildServerMac()
    {
        var bpo = new BuildPlayerOptions
        {
            scenes = paths,
            locationPathName = "BuildMac/Server/ServerBuild.app",
            options = BuildOptions.None,
            target = BuildTarget.StandaloneOSX,
        };
        BuildPipeline.BuildPlayer(bpo);
    }

    [MenuItem("Tools/Build Game/Build Server OSX Headless")]
    public static void BuildServerMacHeadless()
    {
        var bpo = new BuildPlayerOptions
        {
            scenes = paths,
            locationPathName = "BuildMac/ServerHeadless/ServerBuildHeadless.app",
            options = BuildOptions.EnableHeadlessMode,
            target = BuildTarget.StandaloneOSX,
        };
        BuildPipeline.BuildPlayer(bpo);
    }

}
#endif