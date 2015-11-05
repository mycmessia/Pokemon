using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SkillGenerator {

	public static Skill Create (int skillIndex)
	{
		Dictionary<string, string> dict = DataController.instance.skillsDataList[skillIndex];
		
		SkillType skt = (SkillType)int.Parse (dict["skillType"]);
		switch (skt)
		{
			case SkillType.SkillDamage:
				return new SkillDamage (skillIndex);
			default:
				return new SkillEmpty ();
		}
	}
	
	public static Skill Create ()
	{
		return new SkillEmpty ();
	}
	
}
