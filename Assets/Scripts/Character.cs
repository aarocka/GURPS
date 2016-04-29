using UnityEngine;
using UnityEngine.UI;
using System.Collections;
[AddComponentMenu("shit dicks")]
public class Character : MonoBehaviour {

	//these variables are passed to the back end every turn
	public int totalHealth;
	public int currentHealth;
	public int totalActionPoints;
	public int currentActionPoints;
	public string charName{ get; set;}
	public double posX{ get; set;}
	public double posY{ get; set;}
	public int playerNumber{ get; set; }
	public bool isDead{ get; set;}

	//stats
	int damageDice{get; set;}
	int damageAdds{ get; set;}
	int attackMod{ get; set;}//this is the number added or subtracted to the 3d6 rolled for attack
	int attackSkillLvl{get; set;}
	int activeDefense{ get; set;}

	public Text health;
	public Text actionPoints;

	//constructor
	public Character(){
	}

	void Start(){
		totalHealth = 10;
		currentHealth = 9;
		totalActionPoints = 10;
		currentActionPoints = 9;

		setHealth ();
		setActionPoints ();
	}
	void Update(){
	}

	public void attack(Character enemy, int enemyDefenseMod, int playerAttackMod){
		int attackRoll;
		int damageRoll;
		int enemyDefenseRoll;

		attackRoll = Random.Range (3, 18) + playerAttackMod;
		damageRoll = ((int)(Random.value * 6) * damageDice + damageAdds + damageDice);
		enemyDefenseRoll = Random.Range(3,18) + enemyDefenseMod;

		if(attackRoll <= attackSkillLvl){
			if(enemyDefenseRoll >= enemy.activeDefense){
				enemy.totalHealth = enemy.totalHealth - damageRoll;
			}
		}

				

	}

	void setHealth(){
		health.text = "Player HP: " + currentHealth.ToString () + "/" + totalHealth.ToString ();
	}
	void setActionPoints(){
		actionPoints.text = "Player AP; " + currentActionPoints.ToString () + "/" + totalActionPoints.ToString ();
	}
}
