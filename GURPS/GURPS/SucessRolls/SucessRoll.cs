using System;

namespace SucessRoll
{
	public class SucessRoll
	{
		int sucMargin{ set; get;}
		int failMargin{ set; get;}
		int modifier{set; get;}
		int skillLvl{ set; get;}
		bool hasSucceeded{ set; get;}

		public SucessRoll (int modifier, int skillLvl)
		{
			this.modifier = modifier;
			this.skillLvl = skillLvl;
			roll ();
		}
		public void roll()
		{
			//roll 3d6
			DiceRoll r = new DiceRoll (3, 0);

			//determine if roll has suceeded
			if (r.result () <= (skillLvl + modifier))
				hasSucceeded = true;
			else
				hasSucceeded = false;

			//determin margin of failure or sucess
			if (hasSucceeded = true) {
				sucMargin = skillLvl - r;
				failMargin = null;
			} else {
				failMargin = r - skillLvl;
				sucMargin = null
			}



			
		}
	}
}

