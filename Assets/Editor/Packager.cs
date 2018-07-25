using UnityEditor;
using UnityEngine;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

public class Packager
{
    // 生成AssetBundle的目录
    public static string BUILD_PATH = Application.streamingAssetsPath;

    [MenuItem("Tools/Build iOS Resources", false, 100)]
    public static void BuildiOSResource()
    {
        BuildAssetResource(BuildTarget.iOS);
    }

    [MenuItem("Tools/Build Android Resources", false, 101)]
    public static void BuildAndroidResource()
    {
        BuildAssetResource(BuildTarget.Android);
    }

    [MenuItem("Tools/Build MacOS Resources", false, 102)]
    public static void BuildMacOSResource()
    {
        BuildAssetResource(BuildTarget.StandaloneOSX);
    }

    [MenuItem("Tools/Build Windows Resources", false, 103)]
    public static void BuildWindowsResource()
    {
        BuildAssetResource(BuildTarget.StandaloneWindows);
    }

    /// <summary>
    /// 生成绑定素材
    /// </summary>
    public static void BuildAssetResource(BuildTarget target)
    {
        if (Directory.Exists(BUILD_PATH))
        {
            Directory.Delete(BUILD_PATH, true);
        }
        Directory.CreateDirectory(BUILD_PATH);

        BuildPipeline.BuildAssetBundles(BUILD_PATH, BuildAssetBundleOptions.None, target);

        AssetDatabase.Refresh();
    }

}