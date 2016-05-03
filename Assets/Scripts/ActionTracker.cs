using UnityEngine;
using System.Collections;

public class ActionTracker {
	bool hasAttacked{ get; set;}
	int dmgDealt{ get; set;} 
	int playerHealth{ get; set;}
	float[] move = new float[2];


	public ActionTracker ()
	{
		hasAttacked=false;
		dmgDealt=0; 
		playerHealth=0;
		move[0] = 0.0f;
		move [1] = 0.0f;
	}

	public float[] getMove()
	{
		return move; 
	}
	public void setMove(float[] newMove)
	{
		this.move = newMove;
	}
}
