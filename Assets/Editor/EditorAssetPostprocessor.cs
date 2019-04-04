using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class EditorAssetPostprocessor : AssetPostprocessor  {

	//模型导入之前调用
	public void OnPreprocessModel()
	{
		// Debug.Log ("OnPreprocessModel="+this.assetPath);
	}

	//模型导入之前调用
	public void OnPostprocessModel(GameObject go)
	{
		// Debug.Log ("OnPostprocessModel="+go.name);
	}

	//纹理导入之前调用，针对入到的纹理进行设置
	public void OnPreprocessTexture()
	{
		//Debug.Log ("OnPreProcessTexture="+this.assetPath);
		//TextureImporter impor = this.assetImporter as TextureImporter;
		//impor.textureFormat = TextureImporterFormat.ARGB32;
		//impor.maxTextureSize = 512;
		//impor.textureType = TextureImporterType.Default;
		//impor.mipmapEnabled = false;
	}

	public void OnPostprocessTexture(Texture2D tex)
	{
		// Debug.Log ("OnPostProcessTexture="+this.assetPath);
	}

 
	public void OnPostprocessAudio(AudioClip clip)
	{
	    
	}
	public void OnPreprocessAudio()
	{
		//AudioImporter audio = this.assetImporter as AudioImporter;
		//audio.format = AudioImporterFormat.Compressed;
	}
	//所有的资源的导入，删除，移动，都会调用此方法，注意，这个方法是static的
	public static void OnPostprocessAllAssets(string[]importedAsset,string[] deletedAssets,string[] movedAssets,string[]movedFromAssetPaths)
	{
		Debug.Log ("OnPostprocessAllAssets");
		foreach (string str in importedAsset) {
			//Debug.Log("importedAsset = "+str);
            if(str.IndexOf(".mat") != -1)
            {
                var material = AssetDatabase.LoadAssetAtPath<Material>(str);
                if(material != null)
                {
                    var texPath = str.Replace("/Material/", "/Texture2D/").Replace(".mat", ".png");
                    var texture = AssetDatabase.LoadAssetAtPath<Texture2D>(texPath);
                    if(texture != null)
                    {
                        material.mainTexture = texture;
                        Debug.Log("设置材质球MainTexture成功 material:" + material.name + " texture:" + texture.name);
                    }
                    else
                    {
                        //材质后缀是_L.mat
                        if (str.IndexOf("_L.mat") != -1)
                        {
                            texPath = str.Replace("/Material/", "/Texture2D/").Replace("_L.mat", ".png");
                            texture = AssetDatabase.LoadAssetAtPath<Texture2D>(texPath);
                            if (texture != null)
                            {
                                material.mainTexture = texture;
                                Debug.Log("设置材质球MainTexture成功 material:" + material.name + " texture:" + texture.name);
                            }
                        }
                    }
                }
            }
		}
		foreach (string str in deletedAssets) {
			//Debug.Log("deletedAssets = "+str);
		}
		foreach (string str in movedAssets) {
			//Debug.Log("movedAssets = "+str);
		}
		foreach (string str in movedFromAssetPaths) {
			//Debug.Log("movedFromAssetPaths = "+str);
		}

        AssetDatabase.SaveAssets();
	}
}
