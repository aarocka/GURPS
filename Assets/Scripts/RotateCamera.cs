using UnityEngine;
using System.Collections;

public class RotateCamera : MonoBehaviour {

	public int speed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.A))
			transform.Rotate (Vector3.up * speed * Time.deltaTime);
		if(Input.GetKey(KeyCode.D))
			transform.Rotate(Vector3.down * speed * Time.deltaTime);
	
	}
}
