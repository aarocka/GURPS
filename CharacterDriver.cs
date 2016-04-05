using System;

namespace GURPS
{
	public class CharacterDriver
	{
		public static void Main(string[] args)
		{
			Character tim = new Character (15, 17, 11, 13);

			Console.WriteLine (tim.ToString ()); 

			DiceRoll roll = new DiceRoll (3, 2);
			Console.WriteLine (roll.roll());
		}
	}
}

