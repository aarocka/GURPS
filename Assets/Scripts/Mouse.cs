using UnityEngine;
using System.Collections;

public class Mouse : MonoBehaviour {
    Unit player;
    // Use this for initialization
    void Start () {
        //Finds a gameobject that is tagged with player
        //We now have access to class unit
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Unit>();
    }
	
	// Update is called once per frame
	void Update () {

        //TODO handle touch screen
        Ray mouseRay = Camera.current.ScreenPointToRay(Input.mousePosition);

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
                //if we right click a hex
                if (mousedOverObj.GetComponent<Hex>() != null)
                {
                    /* Ideally we should be passing the unit script the tile we selected
                     * rather than it's coord's. This way it might be easier to implement
                     * pathfinding or only allow movement to adjecent tiles. That kind of
                     * logic would be handled through the Unit script.
                     */
                    Debug.Log("U right clicked a hex tile");
                    player.destination = mousedOverObj.transform.position;
                }
                //if we right click a unit
                else if (mousedOverObj.GetComponent<Unit>()!=null)
                {
                    Debug.Log("You right clicked a unit");
                }
            }

        }
	}
   
}
