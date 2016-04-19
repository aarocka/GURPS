using UnityEngine;
using UnityEditor;
using System.Collections;
public class HexGrid : EditorWindow {
	int gridWidth;
	int gridHeight;

	[MenuItem ("Window/Hex Creator")]
	public static void  ShowWindow () {
		EditorWindow.GetWindow(typeof(HexGrid));
	}
	void OnGUI(){
		GUILayout.Label ("Field Size", EditorStyles.boldLabel);
		gridWidth = EditorGUILayout.IntField ("Field Width", gridWidth);
		gridWidth = EditorGUILayout.IntField ("Field Height", gridHeight);
	}
}
