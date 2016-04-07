using System;

namespace Skill
{
	public class Skill
	{
		string name;
		string controllingAttribute;
		int level;
		int characterPoints;

		int attributeScore;

		//difficulty works similar to conAtt in that different int values correspond
		//to different difficulty levels
		//key: 1 = easy; 2 = average; 3 = hard; 4 = very hard
		int difficulty;
		int techLevel;
		int[] pointCosts = new int[] {1,2,4,8,12,16,20,24,28}

		public Skill (string name, string conAtt, int difficulty, int techLevel)
		{
			this.name = name;
			this.difficulty = difficulty;
			this.techLevel = techLevel;
			this.controllingAttribute = conAtt;
			
		}

		//this method imports the characters stats for use inside the skill class
		public void importStats(int attScore, int charPoints)
		{
			this.attributeScore = attScore;
			this.characterPoints = charPoints;
		}

		//these two methods return the characters stats back to the character class
		public int returnAttScore()
		{
			return attributeScore;
		}
		public int returnCharPoints()
		{
			return characterPoints;	
		}

		public void setLevel()
		{
			switch (value) {
			case 1:
				this.level = attributeScore - 1;
				break;
			case 1:
				this.level = attributeScore - 1;
				break;
			case 1:
				this.level = attributeScore - 1;
				break;
			case 1:
				this.level = attributeScore - 1;
				break;
			}

		}
	}
}

