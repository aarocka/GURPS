using UnityEngine;
using System.Collections;

public class ClickableTile : MonoBehaviour {

	public int tileX;
	public int tileY;
	public Movement map;

	//test to see if it clicks
	void OnMouseuUp(){
		Debug.Log ("Click!");
		map.moveTo (tileX, tileY);
	}
}
