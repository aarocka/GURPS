using UnityEngine;
using System.Collections;

public class SwitchCamera : MonoBehaviour {

	public Camera cam1;
	public Camera cam2;
	public Camera cam3;
	public Camera cam4;

	// Use this for initialization
	void Start () {
		cam1.enabled = true;
		cam2.enabled = false;
		cam3.enabled = false;
		cam4.enabled = false;

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Q) && (cam2.enabled == true || cam3.enabled == true || cam4.enabled == true)) {
			cam1.enabled = true;
			cam2.enabled = false;
			cam3.enabled = false;
			cam4.enabled = false;
		}
		else if (Input.GetKeyDown(KeyCode.W) && (cam1.enabled == true || cam3.enabled == true || cam4.enabled == true)) {
			cam1.enabled = false;
			cam2.enabled = true;
			cam3.enabled = false;
			cam4.enabled = false;
		}
		else if (Input.GetKeyDown(KeyCode.E) && (cam1.enabled == true || cam2.enabled == true || cam4.enabled == true)) {
			cam1.enabled = false;
			cam2.enabled = false;
			cam3.enabled = true;
			cam4.enabled = false;
		}
		else if (Input.GetKeyDown(KeyCode.R) && (cam1.enabled == true || cam2.enabled == true || cam3.enabled == true)) {
			cam1.enabled = false;
			cam2.enabled = false;
			cam3.enabled = false;
			cam4.enabled = true;
		}
	
	}
}
