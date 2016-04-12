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
		}
		public void roll()
		{
			DiceRoll r = new DiceRoll (3, 0);

			if (r.result () <= (skillLvl + modifier))
				hasSucceeded = true;
			else
				hasSucceeded = false;

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

