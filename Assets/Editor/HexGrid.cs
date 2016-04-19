using UnityEngine;
using UnityEditor;
using System.Collections;
public class HexGrid : EditorWindow {
	[MenuItem ("Window/Hex Creator")]
	public static void  ShowWindow () {
		EditorWindow.GetWindow(typeof(HexGrid));
	}
	void OnGUI(){
		
	}
}
