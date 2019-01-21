using UnityEngine;
using UnityEditor;

public static class ScriptableObjectUtils {
	[MenuItem("Assets/Create/Asset From Scriptable Object", false)]
	public static void CreateObjectAsAsset() {
		var activeObject = Selection.activeObject;
		string assetPath = AssetDatabase.GetAssetPath(activeObject);
		MonoScript monoScript = (MonoScript) AssetDatabase.LoadAssetAtPath(assetPath, typeof(MonoScript));
		if (monoScript == null) {
			return;
		}
		
		System.Type scriptType = monoScript.GetClass();
		
		string path = EditorUtility.SaveFilePanelInProject("Save asset as .asset", scriptType.Name + ".asset", "asset", "Please enter a file name");
		
		if (path.Length == 0) {
			return;
		}
		
		try {
			ScriptableObject inst = ScriptableObject.CreateInstance(scriptType);
			AssetDatabase.CreateAsset(inst, path); 
			EditorUtility.FocusProjectWindow();
			Selection.activeObject = inst;
		} catch (System.Exception e) {
			Debug.LogException(e);
		}
	}
}