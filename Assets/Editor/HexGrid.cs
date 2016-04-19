using UnityEngine;
using UnityEditor;
using System.Collections;
public class HexGrid : EditorWindow {
	int gridWidth = 2;
	int gridHeight = 2;
	GameObject prefabTemplate;
	string mapObjectName = "";

	public int hiworld= 1;
	[MenuItem ("Window/Hex Creator")]
	public static void  ShowWindow () {
		EditorWindow.GetWindow(typeof(HexGrid));
	}
	void OnGUI(){
		GUILayout.Label ("Hex Grid Creator", EditorStyles.boldLabel);
		mapObjectName = EditorGUILayout.TextField ("Text Field", mapObjectName);
		gridWidth = EditorGUILayout.IntField ("Field Width", gridWidth);
		gridHeight = EditorGUILayout.IntField ("Field Height", gridHeight);
		if (GUILayout.Button ("Hello")) {
			Debug.Log ("Creating Grid Size " +gridWidth+"x"+gridHeight);
		}
	}
}
