using UnityEngine;
using System.Collections;

public class Mouse : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        //TODO handle touch screen
        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hitInfo;

        if (Physics.Raycast(mouseRay, out hitInfo) ){
            GameObject mousedOverObj = hitInfo.collider.transform.gameObject;
            Debug.Log("Mouse is over something" + hitInfo.collider.transform.parent.name);

            if (Input.GetButton(0))
            {
               //some stubbed function for attacking things i guess
            }

            //Move player to selected tile
            if (Input.GetMouseButton(1))
            {
                Debug.Log("U clikd");
            }

        }
	}
}
