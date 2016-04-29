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
	
	}
	
	// Update is called once per frame
	void Update () {
		aquireTarget ();
	}

	//this functio
	void aquireTarget(){
		if (Input.GetMouseButtonDown (0)) {
			Ray ray = Camera.current.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit = new RaycastHit();
			if(Physics.Raycast(ray, out hit, 1000)){
				target = hit.collider.GetComponent<Character>();
				Debug.Log("target selected");

			}
		}
	}
	void setTargetStats(){
		targetAP.text = ("TargetAP: " + target.currentActionPoints + "/" + target.totalActionPoints);
		targetHP.text = ("TargetAP: " + target.currentHealth + "/" + target.totalHealth);

	}
	void attackTarget(){
		player.attack (target, 0, 0);
		
	}
}
