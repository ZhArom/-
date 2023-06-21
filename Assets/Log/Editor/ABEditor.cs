using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ABEditor : Editor {

    [MenuItem("AssetBundle/创建win64的AB包")]
    public static void CreateABS()
    {
        string path = System.IO.Path.Combine(Application.streamingAssetsPath, "ABS");
        if (!System.IO.Directory.Exists(path))
        {
            System.IO.Directory.CreateDirectory(path);
        }
        BuildPipeline.BuildAssetBundles(path, BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows64);
    }

    [MenuItem("AssetBundle/打开沙盒路径")]
    public static void OpenFilePath()
    {
        if (!System.IO.Directory.Exists(Application.persistentDataPath))
        {
            System.IO.Directory.CreateDirectory(Application.persistentDataPath);
        }
        EditorUtility.RevealInFinder(Application.persistentDataPath);
    }
}
