using UnityEditor;
using UnityEngine;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

public class Packager
{
    // 生成的目录
    public static string BUILD_PATH = Application.dataPath + "/AssetBundles";

    [MenuItem("AssetBundles/Build iOS Resources", false, 100)]
    public static void BuildiOSResource()
    {
        BuildAssetResource(BuildTarget.iOS);
    }

    [MenuItem("AssetBundles/Build Android Resources", false, 101)]
    public static void BuildAndroidResource()
    {
        BuildAssetResource(BuildTarget.Android);
    }

    [MenuItem("AssetBundles/Build MacOS Resources", false, 102)]
    public static void BuildMacOSResource()
    {
        BuildAssetResource(BuildTarget.StandaloneOSX);
    }

    [MenuItem("AssetBundles/Build Windows Resources", false, 102)]
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