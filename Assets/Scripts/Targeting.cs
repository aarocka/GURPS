using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Targeting : MonoBehaviour {

	public Camera cam;
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

	//this function
	void aquireTarget(){

		if (Input.GetMouseButtonDown (0)) {
			Ray ray = cam.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			if(Physics.Raycast(ray, out hit)){
				GameObject mousedOverObj = hit.collider.transform.parent.gameObject;
				Debug.Log("target selected " + hit.collider.transform.parent.name);

			}
		}
	}
	/*
	//this displays the targets health in the UI
	void setTargetStats(){
		targetAP.text = ("TargetAP: " + target.currentActionPoints + "/" + target.totalActionPoints);
		targetHP.text = ("TargetHP: " + target.currentHealth + "/" + target.totalHealth);

	}
	public void attackTarget(){
		player.attack (target, 0, 0);
		setTargetStats();
		
	}
	*/
}
