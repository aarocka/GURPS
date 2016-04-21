using UnityEngine;
using UnityEditor;
using System.Collections;

public class HexGrid : EditorWindow {
	int gridWidth = 2;
	int gridHeight = 2;

	string hexPrefabName = "";

	float xOffset = 0.882f;
	float zOffset = 0.764f;

	public int hiworld= 1;
	[MenuItem ("Window/Hex Creator")]
	public static void  ShowWindow () {
		EditorWindow.GetWindow(typeof(HexGrid));
	}
	void OnGUI(){
		GUILayout.Label ("Hex Grid Creator", EditorStyles.boldLabel);
		hexPrefabName = EditorGUILayout.TextField ("Text Field", hexPrefabName);
		//prefabTemplate = EditorGUILayout.ObjectField(prefabTemplate, typeof(GameObject), true);
		gridWidth = EditorGUILayout.IntField ("Field Width", gridWidth);
		gridHeight = EditorGUILayout.IntField ("Field Height", gridHeight);
				
		if (GUILayout.Button ("Hello")) {
			//set hexPrefab to a game object with the name hexPrefabName
			Object hexPrefab = AssetDatabase.LoadAssetAtPath("Assets/Prefabs/Hex.prefab", typeof(GameObject));

			//TODO Add creation
			Debug.Log ("Creating Grid Size " +gridWidth+"x"+gridHeight);

			for (int x = 0; x < gridWidth; x++) {
				for (int y = 0; y < gridHeight; y++) {

					float xPos = x * xOffset;

					// Are we on an odd row?
					if( y % 2 == 1 ) {
						xPos += xOffset/2f;
					}

					GameObject hex_go = (GameObject)Instantiate(hexPrefab, new Vector3( xPos,0, y * zOffset  ), Quaternion.identity  );

					// Name the gameobject something sensible.
					hex_go.name = "Hex_" + x + "_" + y;

					// Make sure the hex is aware of its place on the map
					hex_go.GetComponent<Hex>().x = x;
					hex_go.GetComponent<Hex>().y = y;

					// For a cleaner hierachy, parent this hex to the map
					//hex_go.transform.SetParent(this.transform);

					// TODO: Quill needs to explain different optimization later...
					hex_go.isStatic = true;

				}
			}


		}
	}
}
