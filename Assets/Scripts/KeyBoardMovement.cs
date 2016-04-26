using UnityEngine;
using System.Collections;

public class KeyBoardMovement : MonoBehaviour {

		void Update ()
		{
		

			//Left movement
		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			Vector3 position = this.transform.position;
			//prevents going off the board in x direction
			if (position.x != -1) {
				position.x--;
				this.transform.position = position;
			}
		}
			//right movement
			if (Input.GetKeyDown (KeyCode.RightArrow)) {
				Vector3 position = this.transform.position;
			if (position.x != +1) {
				position.x++;
				this.transform.position = position;
			}
			}

			//up movement
			if (Input.GetKeyDown (KeyCode.UpArrow)) {
				Vector3 position = this.transform.position;
			if (position.z != +1) {
				position.z++;
				this.transform.position = position;
			}
			}
			//down movement
			if (Input.GetKeyDown (KeyCode.DownArrow)) {
				Vector3 position = this.transform.position;
			if (position.z != -1) {
				position.z--;
				this.transform.position = position;
			}
			}

		}
	}