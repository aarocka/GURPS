using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Targeting : MonoBehaviour {

	public Character target;
	public Character player;

	public Text targetAP;
	public Text targetHP;
	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag("Player").GetComponent<Character> ();
	}
	
	// Update is called once per frame
	void Update () {
		aquireTarget ();
	}

	//this functio
	void aquireTarget(){
		if (Input.GetMouseButtonDown (0)) {
<<<<<<< HEAD
<<<<<<< HEAD
			Ray ray = cam.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
=======
=======
>>>>>>> parent of b98740a... worked out more bugs
			Ray ray = Camera.current.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit = new RaycastHit();
>>>>>>> parent of b98740a... worked out more bugs
			if(Physics.Raycast(ray, out hit)){
				GameObject mousedOverObj = hit.collider.transform.parent.gameObject;
				Debug.Log("target selected " + hit.collider.transform.parent.name);

			}
		}
	}
<<<<<<< HEAD
<<<<<<< HEAD
	/*
	//this displays the targets health in the UI
=======
>>>>>>> parent of b98740a... worked out more bugs
=======
>>>>>>> parent of b98740a... worked out more bugs
	void setTargetStats(){
		targetAP.text = ("TargetAP: " + target.currentActionPoints + "/" + target.totalActionPoints);
		targetHP.text = ("TargetAP: " + target.currentHealth + "/" + target.totalHealth);

	}
	void attackTarget(){
		player.attack (target, 0, 0);
		
	}
	*/
}
