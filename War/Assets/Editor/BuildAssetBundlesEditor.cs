using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

/// <summary>
/// 打包AB资源的类.
/// </summary>
public class BuildAssetBundlesEditor
{
    [MenuItem("Asset Bundle/Windows Resoures")]
    public static void AssetBundelBuildWindows()
    {
        BuildPipeline.BuildAssetBundles(Application.streamingAssetsPath,
            BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows);
    }

    [MenuItem("Asset Bundle/Android Resoures")]
    public static void AssetBundelBuildAndroid()
    {
        BuildPipeline.BuildAssetBundles(Application.streamingAssetsPath,
            BuildAssetBundleOptions.None, BuildTarget.Android);
    }
}
