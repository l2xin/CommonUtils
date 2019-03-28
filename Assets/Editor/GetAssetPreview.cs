using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class GetAssetPreview : MonoBehaviour {

    [MenuItem("Assets/PreviewPrefab %#R")]
    public static void PreviewPrefab()
    {
        UnityEngine.Object[] arr = Selection.GetFiltered(typeof(UnityEngine.Object), SelectionMode.DeepAssets);
        if(arr == null)
        {
            return;
        }
        for(int i = 0; i < arr.Length; i++)
        {
            if(arr[i] is GameObject)
            {
                GetAssetPreview.SaveOnePreview(arr[i] as GameObject, AssetDatabase.GetAssetPath(arr[i]));
            }
        }
        AssetDatabase.Refresh();
    }

    private static void SaveOnePreview(GameObject go, string filePath)
    {
        var texture2d = AssetPreview.GetAssetPreview(go);
        if(texture2d == null)
        {
            return;
        }
        byte[] bytes = texture2d.EncodeToPNG();
        if (bytes == null)
        {
            return;
        }
        string xx = filePath.Replace(".prefab", ".png").Replace("Assets", "");
        string filename = Application.dataPath + xx;
        Debug.Log("filename:" + filename);
        System.IO.File.WriteAllBytes(filename, bytes);
        bytes = null;
        texture2d = null;

    }
   

}
