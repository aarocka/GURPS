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
        
        //If the mouse is hovering over something
        if (Physics.Raycast(mouseRay, out hitInfo) ){
            GameObject mousedOverObj = hitInfo.collider.transform.parent.gameObject;
            //Debug.Log("Are hovering over" + hitInfo.collider.transform.parent.name);

            if (Input.GetMouseButton(0))
            {
               //some stubbed function for attacking things i guess
            }

            //Move player to selected tile
            if (Input.GetMouseButton(1))
            {
                if (mousedOverObj.GetComponent<Hex>() != null)
                {
                    Debug.Log("U right clicked a hex tile");
                }
            }

        }
	}

   
}
