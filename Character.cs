using System;

namespace GURPS
{
	public class Character
	{
		//secondary stats
		public int st{get; set;}//strength
		public int dx{get; set;}//dexterity
		public int iq{get; set;}//intellegence
		public int ht{get; set;}//health

		//secondary stats
		public int bl{get; set;}//basic lift
		public int currentHP{get; set;}
		public int totalHP{get; set;}
		public int will{get; set;}
		public int per{get; set;}//perception
		public int totalFP{get; set;}//fatigue points
		public int currentFP{get; set;}
		public double basicSpeed{get; set;}
		public int basicMove{ get; set;}
		public int charcterPoints{ get; set;}


		public Character(int st, int dx, int iq, int ht)
		{
			this.st = st;
			this.dx = dx;
			this.iq = iq;
			this.ht = ht;

			//this block of code calls all the gen methods and generates the secondary characteristics
			genBL();
			genTotalHP();
			genWill();
			genPer();
			genTotalFP();
			genBasicSpeed();
			genBasicMove();
		}

		//the following methods generate the default secondary characteristics of the character
		public void genBL()
		{
			this.bl = (st * st) / 5; 
		}
		public void genTotalHP()
		{
			this.totalHP = this.st;
		}
		public void genWill()
		{
			this.will = this.iq;
		}
		public void genPer()
		{
			this.per = this.iq;
		}
		public void genTotalFP()
		{
			this.totalFP = this.ht;
		}
		public void genBasicSpeed()
		{
			this.basicSpeed = ((double)ht + (double)dx) / 4;
		}
		public void genBasicMove()
		{
			this.basicMove = (int)basicSpeed;
		}

		public override string ToString ()
		{
			return string.Format ("[Character: st={0}, dx={1}, iq={2}, ht={3}, bl={4}, currentHP={5}, totalHP={6}, will={7}, per={8}, totalFP={9}, currentFP={10}, basicSpeed={11}, basicMove={12}, charcterPoints={13}]", st, dx, iq, ht, bl, currentHP, totalHP, will, per, totalFP, currentFP, basicSpeed, basicMove, charcterPoints);
		}

		//these methods increase and dectrease character stats and adjust the charcters character
		//points accordingly
		//to increase a stat use a positive number.  to decrease it use a negaitive number

		//primary stats
		public void modStrength(int value)
		{
			st = st + value;
			characterPoints = characterPoints - (value * 10);
		}
		public void modDexterity(int value)
		{
			dx = dx + value;
			characterPoints = characterPoints - (value * 20);
		}
		public void modIntellegence(int value)
		{
			iq = iq + value;
			characterPoints = characterPoints - (value * 20);
		}
		public void modHealth(int value)
		{
			ht = ht + value;
			characterPoints = characterPoints - (value * 10);
		}

		//secondary stats
		public void modTotalHP(int value)
		{
			totalHP = totalHP + value;
			characterPoints = characterPoints - (value * 2);
		}
		public void modWill(int value)
		{
			will = will + value;
			characterPoints = characterPoints - (value * 5);
		}
		public void modPerception(int value)
		{
			per = per + value;
			characterPoints = characterPoints - (value * 5);
		}
		public void modCurrentFP(int value)
		{
			currentFP = currentFP + value;
			characterPoints = characterPoints - (value * 3);
		}
		public void modBasicSpeed(int value)
		{
			basicSpeed = basicSpeed + (value * .25);
			characterPoints = characterPoints - (value * 5);
		}
		public void modBasicMove(int value)
		{
			basicMove = basicMove + value;
			characterPoints = characterPoints - (value * 5);
		}

		//these mod methods do not change character points because they
		//are used when dealing damage or healing
		public void modCurrentHP(int value)
		{
			currentHP = currentHP + value;
		}
		public void modCurrentFP(int value)
		{
			currentHP = currentHP + value;
		}

	}
}

