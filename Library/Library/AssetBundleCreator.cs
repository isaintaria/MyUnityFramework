using UnityEngine;
using UnityEditor;

public class AssetBundleCraetor
{
    [MenuItem("Assets/Build AssetBundles")]
    static public void BuildAssetBundlesAndroid()
    {
        string path = EditorUtility.SaveFolderPanel("Save Resource", "", "AssetBundles");

        if (path.Length != 0)
        {
            BuildPipeline.BuildAssetBundles(path, BuildAssetBundleOptions.None, BuildTarget.Android);
        }
    }
}
