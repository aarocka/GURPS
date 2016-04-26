using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	public GameObject selectedUnit;
	public TileType[] tileTypes;

	float xOffset = 0.882f;
	float zOffset = 0.764f;

	int[,] hexTiles;

	int mapX = 21;
	int mapY = 21;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		for (int x = 0; x < mapX; x++) {
			for (int y = 0; x < mapY; y++) {
				TileType tt = tileTypes [hexTiles [x, y]];
				GameObject go = (GameObject)Instantiate (tt.tileVisualPrefab, new Vector3 (mapX, 0, mapY));
		
				ClickableTile ct = go.GetComponent<ClickableTile>();
				ct.tileX = mapX;
				ct.tileY = mapY; 
				ct.map = this;
			}
		}
	}

	public void moveTo(int x, int y){
		selectedUnit.transform.position = Vector3 (x, 0, y); 
	}

}
