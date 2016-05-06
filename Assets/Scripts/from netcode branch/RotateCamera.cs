using UnityEngine;
using System.Collections;

public class RotateCamera : MonoBehaviour {

	public int speed;//the speed at wich the camera rotates

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		//when the user presses A the camera rotates left
		if (Input.GetKey(KeyCode.A))
			transform.Rotate (Vector3.up * speed * Time.deltaTime);
		//when the user presses D the camera rotates right
		if(Input.GetKey(KeyCode.D))
			transform.Rotate(Vector3.down * speed * Time.deltaTime);
	
	}
}
