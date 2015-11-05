using UnityEngine;
using System.Collections;

public class SkillEmpty : Skill {

	public SkillEmpty ()
	{
		_id = IDController.id;
		_index = -1;
		_name = "No Skill";
		_des = "Please Choose Skill";
		_attr = Attr.None;
		_category = SkillCategory.None;
		_power = 0f;
		_hit = 0f;
		_PP = 0;
		_curPP = 0;
		_preLv = 0;
	}
}
