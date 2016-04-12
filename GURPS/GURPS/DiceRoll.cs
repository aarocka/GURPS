using System;

namespace DiceRoll
{
	public class DiceRoll
	{
		private int dice;//the number of d6s used
		private int adds;//the number added to the roll
		int result{get; set;}
		public DiceRoll (int dice, int adds)
		{
			this.dice = dice;
			this.adds = adds;
			result = roll ();
		}

		public int roll()
		{
			int sum = 0;
			Random rnd = new Random ();

			for (int i = 0; dice > i; i++) {
				int roll = rnd.Next(1,6);
				sum = sum + roll;
			}
			
			return sum + adds;
		}

		public override string ToString ()
		{
			return string.Format ("[DiceRoll: dice={0}, adds={1}, result={2}]", dice, adds, result);
		}
		


	}
}

