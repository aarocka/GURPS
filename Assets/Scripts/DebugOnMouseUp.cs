using UnityEngine;
using System.Collections;

public class DebugOnMouseUp : MonoBehaviour
{

	void RightMouseWasPressed ()
	{
		Cursor.visible = true;// hide mouse arrow
	}


	void MyFunction ()
	{
		Debug.Log ("Left Mouse button up! " + "\n");

		Cursor.visible = false;// Show mouse arrow
	}

	// Update is called once per frame
	void Update ()
	{
		if (Input.GetMouseButtonDown (0))
			RightMouseWasPressed ();// Hide left mouse

		if (Input.GetMouseButtonUp (0))
			MyFunction ();  // Show left mouse
	}
}
