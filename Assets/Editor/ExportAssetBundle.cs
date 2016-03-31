using UnityEngine;
using UnityEditor;

public class ExportAssetBundle
{

    [MenuItem("Assets/Build AssetBundles")]
    static void BuildAllAssetBundles()
    {
        BuildPipeline.BuildAssetBundles("Assets/AssetBundles");
    }
}
