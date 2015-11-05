using UnityEngine;
using System.Collections;
using System.Collections.Generic;			// for List Dictionary

public class SkillDamage : Skill {

	public SkillDamage (int skillIndex)
	{
		Debug.Log ("skill damage construct");
	
		Dictionary<string, string> dict = DataController.instance.skillsDataList[skillIndex];
	
		_id = IDController.id;
		_index = int.Parse (dict["index"]);
		_name = dict["name"];
		_des = dict["des"];
		_attr = (Attr) int.Parse (dict["attr"]);
		_category = (SkillCategory) int.Parse (dict["category"]);
		_power = float.Parse (dict["power"]);
		_hit = float.Parse (dict["hit"]);
		_PP = int.Parse (dict["PP"]);
		_curPP = PP;
		_preLv = int.Parse (dict["preLv"]);
	}
	
	public override void Use (Pokemon self, Pokemon target)
	{
		if (category == SkillCategory.Physical)
		{
			target.HP -= self.attack + power - target.defend;
		}
		else
		{
			target.HP -= self.magicAttack + power - target.magicDefend;
		}
	}

}
